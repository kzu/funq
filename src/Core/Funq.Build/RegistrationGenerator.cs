using System;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;

namespace Microsoft.Practices.Mobile.ContainerModel.Build
{
	public class RegistrationGenerator : Task
	{
		public ITaskItem[] SourceFiles { get; set; }

		public override bool Execute()
		{
			//SourceFiles[0].GetMetadata("Generator")
			//"Funq"
			//SourceFiles[0].GetMetadata("LastGenOutput")
			//"Resources.Designer.cs"
			//SourceFiles[0].GetMetadata("FullPath")
			//"C:\\Temp\\ConsoleApplication1\\ConsoleApplication1\\Properties\\Resources.resx"
			//System.Diagnostics.Debugger.Break();
			return true;
		}
	}
}
