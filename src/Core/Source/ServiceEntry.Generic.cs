using System;

namespace Funq
{
	internal sealed class ServiceEntry<TService> : ServiceEntry, IRegistration<TService>
	{
		public ServiceEntry(object factory)
		{
			this.Factory = factory;
		}

		/// <summary>
		/// The cached service instance if the scope is <see cref="ReuseScope.Hierarchy"/> or 
		/// <see cref="ReuseScope.Container"/>.
		/// </summary>
		public TService Instance { get; set; }

		/// <summary>
		/// The Func delegate that initializes the object after creation.
		/// </summary>
		public Action<Container, TService> Initializer { get; set; }

		public IReusedOwned InitializedBy(Action<Container, TService> initializer)
		{
			this.Initializer = initializer;
			return this;
		}

		/// <summary>
		/// Clones the service entry assigning the <see cref="Container"/> to the 
		/// <paramref name="newContainer"/>. Does not copy the <see cref="Instance"/>.
		/// </summary>
		public ServiceEntry<TService> CloneFor(Container newContainer)
		{
			return new ServiceEntry<TService>(Factory)
			{
				Owner = Owner,
				Reuse = Reuse,
				Container = newContainer,
				Initializer = Initializer,
			};
		}
	}
}
