using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Funq
{
	internal sealed class ServiceEntry<TService> : ServiceEntry, IRegistration<TService>
	{
		public ServiceEntry(object factory)
		{
			base.Factory = factory;
		}

		public IReusedOwned InitializedBy(Action<Container, TService> initializer)
		{
			SetInitializer(initializer);
			return this;
		}
	}
}
