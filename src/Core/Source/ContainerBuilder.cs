using System;
using System.Collections.Generic;

namespace Funq
{
	/// <summary>
	/// Configures a container by receiving registrations that are applied 
	/// to it when a call to <see cref="Build()"/> is performed.
	/// </summary>
	/// <remarks>
	/// In order to build a new container, just call <see cref="Build()"/> 
	/// after specifying the registrations. To add new registrations to an 
	/// existing container, call <see cref="Build(Container)"/> to apply 
	/// them to it.
	/// </remarks>
	public class ContainerBuilder
	{
		List<Registration> registrations = new List<Registration>();

		/// <summary>
		/// Default owner for new registrations. <see cref="Owner.Container"/> by default.
		/// </summary>
		public Owner DefaultOwner { get; set; }
		/// <summary>
		/// Default reuse scope for new registrations. <see cref="ReuseScope.Hierarchy"/> by default.
		/// </summary>
		public ReuseScope DefaultReuse { get; set; }

		/// <summary>
		/// Initializes the builder with the default <see cref="DefaultOwner"/> and <see cref="DefaultReuse"/>.
		/// </summary>
		public ContainerBuilder()
		{
			DefaultOwner = Owner.Container;
			DefaultReuse = ReuseScope.Hierarchy;
		}

		/// <summary>
		/// Builds a new container using the registrations performed so far on the builder.
		/// </summary>
		public Container Build()
		{
			var container = new Container();

			Build(container);

			return container;
		}

		/// <summary>
		/// Applies the registrations performed so far on the builder to an existing container.
		/// </summary>
		/// <param name="container"></param>
		public void Build(Container container)
		{
			foreach (var registration in registrations)
			{
				container.Register(registration.BuildKey(),
					new ServiceEntry
					{
						Factory = registration.Factory, 
						Owner = registration.Owner,
						Reuse = registration.Scope,
						Container = container,
						Initializer = registration.Initializer,
					});
			}
		}

		/// <summary>
		/// Registers the given service by providing a factory delegate to 
		/// instantiate it.
		/// </summary>
		/// <typeparam name="TService">The service type to register.</typeparam>
		/// <param name="factory">The factory delegate to initialize new instances of the service when needed.</param>
		/// <returns>The registration object to perform further configuration via its fluent interface.</returns>
		public IRegistration<TService> Register<TService>(Func<Container, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TService>>(factory);
		}

		/// <summary>
		/// Registers the given service by providing a factory delegate that receives arguments to 
		/// instantiate it.
		/// </summary>
		/// <typeparam name="TService">The service type to register.</typeparam>
		/// <typeparam name="TArg">First argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <param name="factory">The factory delegate to initialize new instances of the service when needed.</param>
		/// <returns>The registration object to perform further configuration via its fluent interface.</returns>
		public IRegistration<TService> Register<TService, TArg>(Func<Container, TArg, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg, TService>>(factory);
		}

		/// <summary>
		/// Registers the given service by providing a factory delegate that receives arguments to 
		/// instantiate it.
		/// </summary>
		/// <typeparam name="TService">The service type to register.</typeparam>
		/// <typeparam name="TArg1">First argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <param name="factory">The factory delegate to initialize new instances of the service when needed.</param>
		/// <returns>The registration object to perform further configuration via its fluent interface.</returns>
		public IRegistration<TService> Register<TService, TArg1, TArg2>(Func<Container, TArg1, TArg2, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TService>>(factory);
		}

		/// <summary>
		/// Registers the given service by providing a factory delegate that receives arguments to 
		/// instantiate it.
		/// </summary>
		/// <typeparam name="TService">The service type to register.</typeparam>
		/// <typeparam name="TArg1">First argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <param name="factory">The factory delegate to initialize new instances of the service when needed.</param>
		/// <returns>The registration object to perform further configuration via its fluent interface.</returns>
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3>(Func<Container, TArg1, TArg2, TArg3, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TArg3, TService>>(factory);
		}

		/// <summary>
		/// Registers the given service by providing a factory delegate that receives arguments to 
		/// instantiate it.
		/// </summary>
		/// <typeparam name="TService">The service type to register.</typeparam>
		/// <typeparam name="TArg1">First argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <param name="factory">The factory delegate to initialize new instances of the service when needed.</param>
		/// <returns>The registration object to perform further configuration via its fluent interface.</returns>
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3, TArg4>(Func<Container, TArg1, TArg2, TArg3, TArg4, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TService>>(factory);
		}

		/// <summary>
		/// Registers the given service by providing a factory delegate that receives arguments to 
		/// instantiate it.
		/// </summary>
		/// <typeparam name="TService">The service type to register.</typeparam>
		/// <typeparam name="TArg1">First argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <param name="factory">The factory delegate to initialize new instances of the service when needed.</param>
		/// <returns>The registration object to perform further configuration via its fluent interface.</returns>
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(factory);
		}

		/// <summary>
		/// Registers the given service by providing a factory delegate that receives arguments to 
		/// instantiate it.
		/// </summary>
		/// <typeparam name="TService">The service type to register.</typeparam>
		/// <typeparam name="TArg1">First argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <typeparam name="TArg6">Sixth argument that should be passed to the factory delegate to create the instace.</typeparam>
		/// <param name="factory">The factory delegate to initialize new instances of the service when needed.</param>
		/// <returns>The registration object to perform further configuration via its fluent interface.</returns>
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(factory);
		}

		private Registration<TService> RegisterImpl<TService, TFunc>(TFunc factory)
		{
			var registration = new Registration<TService>(factory)
			{
				Scope = DefaultReuse,
				Owner = DefaultOwner,
			};

			registrations.Add(registration);

			return registration;
		}
	}
}
