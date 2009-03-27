using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Funq
{
	/// <summary>
	/// Interface to implement by funqlets that provide a convention for types to register, 
	/// which are processed by a T4 template to provide the container registration code 
	/// automatically.
	/// </summary>
	public interface IConventionFunqlet : IFunqlet
	{
		/// <summary>
		/// Provides the registration convention for the funqlet.
		/// </summary>
		Convention GetConvention();
	}

	// Interface definition provided for compatibility with 
	// p&p ContainerModel.

	/// <summary>
	/// Interface used by plugins to contribute registrations 
	/// to an existing container.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IConventionContainerModule : IContainerModule
	{
	}
}
