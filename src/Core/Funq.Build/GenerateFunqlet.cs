#region License
// Microsoft Public License (Ms-PL)
// 
// This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
// 
// 1. Definitions
// 
//   The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
// 
//   A "contribution" is the original software, or any additions or changes to the software.
// 
//   A "contributor" is any person that distributes its contribution under this license.
// 
//   "Licensed patents" are a contributor's patent claims that read directly on its contribution.
// 
// 2. Grant of Rights
// 
//   (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
// 
//   (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
// 
// 3. Conditions and Limitations
// 
//   (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
// 
//   (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
// 
//   (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
// 
//   (D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
// 
//   (E ) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Funq.Build.Properties;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace Funq.Build
{
	/// <include file='Funq.Build.xdoc' path='docs/doc[@for="GenerateFunqlet"]/*'/>
	public class GenerateFunqlet : AppDomainIsolatedTask
	{
		/// <include file='Funq.Build.xdoc' path='docs/doc[@for="GenerateFunqlet.OutputPath"]/*'/>
		public string OutputPath { get; set; }

		/// <include file='Funq.Build.xdoc' path='docs/doc[@for="GenerateFunqlet.TargetNamespace"]/*'/>
		public string TargetNamespace { get; set; }

		/// <include file='Funq.Build.xdoc' path='docs/doc[@for="GenerateFunqlet.Assemblies"]/*'/>
		public ITaskItem[] Assemblies { get; set; }

		/// <include file='Funq.Build.xdoc' path='docs/doc[@for="GenerateFunqlet.Funqlet"]/*'/>
		[Output]
		public ITaskItem Funqlet { get; private set; }

		/// <include file='Funq.Build.xdoc' path='docs/doc[@for="GenerateFunqlet.Execute"]/*'/>
		public override bool Execute()
		{
			// The filter by copylocal should be done in the .targets
			var exportedTypes = this.Assemblies
				.Where(item => item.GetMetadata("CopyLocal") == "true")
				.Select(item => Assembly.LoadFrom(item.GetMetadata("FullPath")))
				.SelectMany(asm => asm.GetTypes())
				.Where(type =>
					type.HasCustomAttribute<ExportAttribute>(false) ||
					type.HasCustomAttribute<InheritedExportAttribute>(true));

			var template = new FunqletTemplate
			{
				Exports = BuildExports(exportedTypes),
				TargetNamespace = TargetNamespace,
			};

			var fileName = Path.Combine(this.OutputPath, this.TargetNamespace + ".Funqlet.cs");

			File.WriteAllText(fileName, template.TransformText(), Encoding.UTF8);

			this.Funqlet = new TaskItem(fileName);

			this.Log.LogMessage(Resources.GenerateSuccessfull, fileName);

			return true;
		}

		private IEnumerable<Export> BuildExports(IEnumerable<Type> exportedTypes)
		{
			foreach (var type in exportedTypes)
			{
				ExportAttribute attr =
					type.GetCustomAttribute<InheritedExportAttribute>(true) ??
					type.GetCustomAttribute<ExportAttribute>(false);

				if (attr.ContractType != null && !attr.ContractType.IsAssignableFrom(type))
				{
					this.Log.LogError(Resources.IncompatibleExportImplementation, type, attr.ContractType);
					continue;
				}

				// Find an importing constructor, or log error.
				var export = new Export
				{
					Contract = new Contract { Type = attr.ContractType ?? type, Name = attr.ContractName },
					Implementation = type,
					Properties = BuildProperties(type),
				};

				if (HasNoDefaultConstructor(type))
				{
					// Find the constructor with the proper attribute
					var ctor = type
						.GetConstructors()
						.FirstOrDefault(c => c.HasCustomAttribute<ImportingConstructorAttribute>());
					// or log an error.
					if (ctor == null)
					{
						this.Log.LogError(Resources.ImportingConstructorMissing, type);
						continue;
					}

					export.Parameters = BuildParameters(ctor);
				}

				yield return export;
			}
		}

		private static bool HasNoDefaultConstructor(Type type)
		{
			return type.GetConstructor(new Type[0]) == null;
		}

		private IEnumerable<PropertyImport> BuildProperties(Type type)
		{
			return type.GetProperties()
				.Where(prop => prop.HasCustomAttribute<ImportAttribute>())
				.Select(prop => new { Property = prop, Import = prop.GetCustomAttribute<ImportAttribute>() })
				.Select(prop => new PropertyImport
				{
					Name = prop.Property.Name,
					Contract = new Contract
					{
						Name = prop.Import.ContractName,
						Type = prop.Import.ContractType ?? prop.Property.PropertyType,
					},
					AllowDefault = prop.Import.AllowDefault,
				});
		}

		private IEnumerable<Import> BuildParameters(ConstructorInfo ctor)
		{
			foreach (var parameter in ctor.GetParameters())
			{
				var import = parameter.GetCustomAttribute<ImportAttribute>();
				if (import == null)
				{
					yield return new Import
					{
						AllowDefault = false,
						Contract = new Contract
						{
							Type = parameter.ParameterType
						},
					};
				}
				else
				{
					yield return new Import
					{
						AllowDefault = import.AllowDefault,
						Contract = new Contract
						{
							Type = import.ContractType ?? parameter.ParameterType,
							Name = import.ContractName
						},
					};
				}
			}
		}
	}
}
