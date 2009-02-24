using System;

namespace Funq
{
	/// <summary>
	/// Determines who is responsible for disposing instances 
	/// registered with a container.
	/// </summary>
	public enum Owner
	{
		/// <summary>
		/// Container should dispose provided instances when it is disposed.
		/// </summary>
		Container,
		/// <summary>
		/// Container does not dispose provided instances.
		/// </summary>
		External,
	}
}
