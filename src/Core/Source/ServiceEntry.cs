using System;

namespace Funq
{
	internal class ServiceEntry : IRegistration
	{
		protected ServiceEntry() {}

		/// <summary>
		/// The Func delegate that creates instances of the service.
		/// </summary>
		public object Factory { get; protected set; }

		/// <summary>
		/// Ownership setting for the service.
		/// </summary>
		public Owner Owner { get; set; }
		/// <summary>
		/// Reuse scope setting for the service.
		/// </summary>
		public ReuseScope Reuse { get; set; }
		/// <summary>
		/// The container where the entry was registered.
		/// </summary>
		public Container Container { get; set; }

		/// <summary>
		/// Specifies the owner for instances, which determines how 
		/// they will be disposed.
		/// </summary>
		public void OwnedBy(Owner owner)
		{
			this.Owner = owner;
		}

		/// <summary>
		/// Specifies the scope for instances, which determines 
		/// visibility of instances across containers and hierarchies.
		/// </summary>
		public IOwned ReusedWithin(ReuseScope scope)
		{
			this.Reuse = scope;
			return this;
		}
	}
}
