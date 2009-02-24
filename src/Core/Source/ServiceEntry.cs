using System;

namespace Funq
{
	internal class ServiceEntry : IRegistration
	{
		protected ServiceEntry() {}

		/// <summary>
		/// The Func delegate that creates instances of the service.
		/// </summary>
		public object Factory { get; set; }
		/// <summary>
		/// The Func delegate that initializes the object after creation.
		/// </summary>
		public object Initializer { get; set; }
		/// <summary>
		/// Ownership setting for the service.
		/// </summary>
		public Owner Owner { get; set; }
		/// <summary>
		/// Scope setting for the service.
		/// </summary>
		public ReuseScope Scope { get; set; }
		/// <summary>
		/// Service instance if <see cref="ReuseScope.Hierarchy"/> or 
		/// <see cref="ReuseScope.Container"/> scoped.
		/// </summary>
		public object Instance { get; set; }
		/// <summary>
		/// The container where the entry was registered.
		/// </summary>
		public Container Container { get; set; }

		/// <summary>
		/// Clones the service entry assigning the <see cref="Container"/> to the 
		/// <paramref name="newContainer"/>. Does not copy the <see cref="Instance"/>.
		/// </summary>
		public ServiceEntry CloneFor(Container newContainer)
		{
			return new ServiceEntry
			{
				Factory = Factory, 
				Owner = Owner, 
				Scope = Scope, 
				Container = newContainer,
				Initializer = Initializer,
			};
		}

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
			this.Scope = scope;
			return this;
		}

		/// <summary>
		/// Sets the initializer delegate. See <see cref="IInitializable{TService}.InitializedBy"/>.
		/// </summary>
		protected void SetInitializer(object initializer)
		{
			this.Initializer = initializer;
		}
	}
}
