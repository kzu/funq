using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel.Composition
{
	/// <include file='Composition.xdoc' path='docs/doc[@for="ExportAttribute"]/*'/>
	// NOTE: we do not support AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method for now.
	// NOTE: we do not support AllowMultiple = true for now.
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class ExportAttribute : Attribute
	{
		/// <include file='Composition.xdoc' path='docs/doc[@for="ExportAttribute.ctor"]/*'/>
		public ExportAttribute()
			: this(null, null)
		{
		}

		/// <include file='Composition.xdoc' path='docs/doc[@for="ExportAttribute.ctor(string)"]/*'/>
		public ExportAttribute(string contractName)
			: this(contractName, null)
		{
		}

		/// <include file='Composition.xdoc' path='docs/doc[@for="ExportAttribute.ctor(Type)"]/*'/>
		public ExportAttribute(Type contractType)
			: this(null, contractType)
		{
		}

		/// <include file='Composition.xdoc' path='docs/doc[@for="ExportAttribute.ctor(string, Type)"]/*'/>
		public ExportAttribute(string contractName, Type contractType)
		{
			this.ContractName = contractName;
			this.ContractType = contractType;
		}

		/// <include file='Composition.xdoc' path='docs/doc[@for="ExportAttribute.ContractType"]/*'/>
		public Type ContractType { get; private set; }

		/// <include file='Composition.xdoc' path='docs/doc[@for="ExportAttribute.ContractName"]/*'/>
		public string ContractName { get; private set; }
	}
}
