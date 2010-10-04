using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel.Composition
{
	/// <include file='Composition.xdoc' path='docs/doc[@for="PartCreationPolicyAttribute"]/*'/>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class PartCreationPolicyAttribute : Attribute
	{
		/// <include file='Composition.xdoc' path='docs/doc[@for="PartCreationPolicyAttribute.ctor"]/*'/>
		public PartCreationPolicyAttribute(CreationPolicy creationPolicy)
		{
			this.CreationPolicy = creationPolicy;
		}

		/// <include file='Composition.xdoc' path='docs/doc[@for="PartCreationPolicyAttribute.CreationPolicy"]/*'/>
		public CreationPolicy CreationPolicy { get; private set; }
	}
}
