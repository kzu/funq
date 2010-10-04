using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel.Composition
{
	/// <include file='Composition.xdoc' path='docs/doc[@for="ImportAttribute"]/*'/>
	// NOTE: we do not support import on fields as that would require the fields to be public, encouraging a bad practice.
	[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class ImportAttribute : Attribute
	{
		/// <include file='Composition.xdoc' path='docs/doc[@for="ImportAttribute.ctor"]/*'/>
		public ImportAttribute()
			: this((string)null)
		{
		}

		/// <include file='Composition.xdoc' path='docs/doc[@for="ImportAttribute.ctor(string)"]/*'/>
		public ImportAttribute(string contractName)
			: this(contractName, null)
		{
		}

		/// <include file='Composition.xdoc' path='docs/doc[@for="ImportAttribute.ctor(Type)"]/*'/>
		public ImportAttribute(Type contractType)
			: this(null, contractType)
		{
		}

		/// <include file='Composition.xdoc' path='docs/doc[@for="ImportAttribute.ctor(string, Type)"]/*'/>
		public ImportAttribute(string contractName, Type contractType)
		{
			this.ContractName = contractName;
			this.ContractType = contractType;
		}

		/// <include file='Composition.xdoc' path='docs/doc[@for="ImportAttribute.AllowDefault"]/*'/>
		public bool AllowDefault { get; set; }

		/// <include file='Composition.xdoc' path='docs/doc[@for="ImportAttribute.ContractType"]/*'/>
		public Type ContractType { get; private set; }

		/// <include file='Composition.xdoc' path='docs/doc[@for="ImportAttribute.ContractName"]/*'/>
		public string ContractName { get; private set; }
	}
}
