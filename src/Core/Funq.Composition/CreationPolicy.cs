using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.ComponentModel.Composition
{
	/// <include file='Composition.xdoc' path='docs/doc[@for="CreationPolicy"]/*'/>
	public enum CreationPolicy
	{
		/// <include file='Composition.xdoc' path='docs/doc[@for="CreationPolicy.Any"]/*'/>
		Any,

		/// <include file='Composition.xdoc' path='docs/doc[@for="CreationPolicy.Shared"]/*'/>
		Shared,

		/// <include file='Composition.xdoc' path='docs/doc[@for="CreationPolicy.NonShared"]/*'/>
		NonShared
	}
}
