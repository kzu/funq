using System;
using System.Collections.Generic;

namespace Funq
{
	/// <summary>
	/// Represents a registration by convention, used by funqlets that 
	/// use the T4-generated conventions for <see cref="IConventionFunqlet"/> 
	/// interface.
	/// </summary>
	public class Convention
	{
		/// <summary>
		/// Initializes the convention with the kind of convention and 
		/// the types to generate registrations for.
		/// </summary>
		public Convention(ConventionKind kind, IEnumerable<Type> typesToRegister)
		{
			this.Kind = kind;
			this.Types = typesToRegister;
			this.Reuse = ReuseScope.Default;
		}

		/// <summary>
		/// Query with types that should get registered by the funqlet.
		/// </summary>
		public IEnumerable<Type> Types { get; private set; }

		/// <summary>
		/// The default reuse scope for registrations.
		/// </summary>
		public ReuseScope Reuse { get; set; }

		/// <summary>
		/// Kind of convention, which defaults to <see cref="ConventionKind.Services"/>.
		/// </summary>
		public ConventionKind Kind { get; set; }
	}

	/// <summary>
	/// Kind of convention, which determines how the T4 template will generate 
	/// the registrations for the types.
	/// </summary>
	public enum ConventionKind
	{
		/// <summary>
		/// Services are registered with their interface (other than the IDisposable 
		/// interface), not their actual concrete type.
		/// </summary>
		Services,
		/// <summary>
		/// Components are registered with their actual type, interfaces are ignored.
		/// </summary>
		Components, 

		// TODO: should we have Both too?
		// TODO: this would require the .As<TInterface> addition, 
		// and also a refactor to keep a single instance for all those 
		// registrations...
	}
}
