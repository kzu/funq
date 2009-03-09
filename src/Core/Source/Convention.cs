using System;
using System.Collections.Generic;

namespace Funq
{
	public class Convention
	{
		public Convention(ConventionKind kind, IEnumerable<Type> typesToRegister)
		{
			this.Kind = kind;
			this.Types = typesToRegister;
			this.Reuse = ReuseScope.Default;
		}

		public IEnumerable<Type> Types { get; private set; }
		public ReuseScope Reuse { get; set; }
		public ConventionKind Kind { get; set; }
	}

	public enum ConventionKind
	{
		Services,
		Components, 
	}
}
