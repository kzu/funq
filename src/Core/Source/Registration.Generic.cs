using System;

namespace Funq
{
	/// <summary>
	/// Internal registration type used by <see cref="ContainerBuilder"/> 
	/// registration methods.
	/// </summary>
	internal class Registration<TService> : Registration, IRegistration<TService>
	{
		internal Registration(object factory)
			: base(typeof(TService), factory)
		{
		}

		public IReusedOwned InitializedBy(Action<Container, TService> initializer)
		{
			SetInitializer(initializer);
			return this;
		}
	}
}
