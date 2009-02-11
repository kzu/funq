using System;
using System.ComponentModel;

namespace Funq
{
	/// <summary>
	/// Representation of a service registration with the 
	/// container, exposing the fluent interface for configuring it.
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	internal abstract class Registration : IRegistration
	{
		internal Registration(Type serviceType, object factory)
		{
			this.ServiceType = serviceType;
			this.Factory = factory;
			this.FactoryType = factory.GetType();
		}

		/// <summary>
		/// Assigns a name to the registered service, so that it can 
		/// be retrieved with <c>Container.ResolveNamed</c> or 
		/// <c>Container.TryResolveNamed</c>.
		/// </summary>
		/// <param name="name">A name for the service.</param>
		public IReusedOwned Named(string name)
		{
			this.Name = name;
			return this;
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

		internal ServiceKey BuildKey()
		{
			return new ServiceKey(ServiceType, FactoryType, Name);
		}

		internal object Factory { get; private set; }
		internal Type ServiceType { get; private set; }
		internal Type FactoryType { get; private set; }
		internal object Initializer { get; private set; }

		/// <summary>
		/// See <see cref="Owner"/>.
		/// </summary>
		public Owner Owner { get; set; }
		/// <summary>
		/// See <see cref="ReuseScope"/>.
		/// </summary>
		public ReuseScope Scope { get; set; }
		/// <summary>
		/// Name to assign to the registered service.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Sets the initializer delegate. See <see cref="IInitializable{TService}.InitializedBy"/>.
		/// </summary>
		protected void SetInitializer(object initializer)
		{
			this.Initializer = initializer;
		}
	}
}
