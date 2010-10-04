using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Funq.Composition
{
	/// <include file='Composition.xdoc' path='docs/doc[@for="ImportingConstructorAttribute"]/*'/>
	[AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
	public class ImportingConstructorAttribute : Attribute
	{
	}
}
