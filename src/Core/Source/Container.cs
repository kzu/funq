using System;
using System.Collections.Generic;

namespace Funq
{
	/// <summary>
	/// Main container class for components, supporting container hierarchies and 
	/// lifetime management of <see cref="IDisposable"/> instances. To configure 
	/// a container, use a <see cref="ContainerBuilder"/>.
	/// </summary>
	public sealed class Container : IDisposable
	{
		Dictionary<ServiceKey, ServiceEntry> services = new Dictionary<ServiceKey, ServiceEntry>();
		// Disposable components include factory-scoped instances that we don't keep 
		// a strong reference to. 
		Stack<WeakReference> disposables = new Stack<WeakReference>();
		// We always hold a strong reference to child containers.
		Stack<Container> childContainers = new Stack<Container>();
		Container parentContainer;

		/// <summary>
		/// Creates a child container of the current one, which exposes its 
		/// current service registration to the new child container.
		/// </summary>
		public Container CreateChildContainer()
		{
			var child = new Container { parentContainer = this };
			childContainers.Push(child);
			return child;
		}

		/// <summary>
		/// Actual registration implementation invoked by the <see cref="ContainerBuilder"/> 
		/// to provide factories to the container.
		/// </summary>
		internal void Register(ServiceKey key, ServiceEntry entry)
		{
			services[key] = entry;
		}

		/// <summary>
		/// Disposes the container and all instances owned by it (see 
		/// <see cref="Owner.Container"/>), as well as all child containers 
		/// created through <see cref="CreateChildContainer"/>.
		/// </summary>
		public void Dispose()
		{
			while (disposables.Count > 0)
			{
				var wr = disposables.Pop();
				var disposable = (IDisposable)wr.Target;
				if (wr.IsAlive)
					disposable.Dispose();
			}
			while (childContainers.Count > 0)
			{
				childContainers.Pop().Dispose();
			}
		}

		#region Resolve

		/// <summary>
		/// Resolves the given service by type, without passing any arguments for 
		/// its construction.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService Resolve<TService>()
		{
			return ResolveNamed<TService>(null);
		}

		/// <summary>
		/// Resolves the given service by type, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService Resolve<TService, TArg>(TArg arg)
		{
			return ResolveNamed<TService, TArg>(null, arg);
		}

		/// <summary>
		/// Resolves the given service by type, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService Resolve<TService, TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
		{
			return ResolveNamed<TService, TArg1, TArg2>(null, arg1, arg2);
		}

		/// <summary>
		/// Resolves the given service by type, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService Resolve<TService, TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			return ResolveNamed<TService, TArg1, TArg2, TArg3>(null, arg1, arg2, arg3);
		}

		/// <summary>
		/// Resolves the given service by type, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService Resolve<TService, TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			return ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4>(null, arg1, arg2, arg3, arg4);
		}

		/// <summary>
		/// Resolves the given service by type, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService Resolve<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			return ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(null, arg1, arg2, arg3, arg4, arg5);
		}

		/// <summary>
		/// Resolves the given service by type, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg6">Sixth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService Resolve<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			return ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(null, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		#endregion

		#region ResolveNamed

		/// <summary>
		/// Resolves the given service by type and name, without passing arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService ResolveNamed<TService>(string name)
		{
			return ResolveCore<TService, Func<Container, TService>>(
				name, f => f(this));
		}

		/// <summary>
		/// Resolves the given service by type and name, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService ResolveNamed<TService, TArg>(string name, TArg arg)
		{
			return ResolveCore<TService, Func<Container, TArg, TService>>(
				name, f => f(this, arg));
		}

		/// <summary>
		/// Resolves the given service by type and name, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService ResolveNamed<TService, TArg1, TArg2>(string name, TArg1 arg1, TArg2 arg2)
		{
			return ResolveCore<TService, Func<Container, TArg1, TArg2, TService>>(
				name, f => f(this, arg1, arg2));
		}

		/// <summary>
		/// Resolves the given service by type and name, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService ResolveNamed<TService, TArg1, TArg2, TArg3>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			return ResolveCore<TService, Func<Container, TArg1, TArg2, TArg3, TService>>(
				name, f => f(this, arg1, arg2, arg3));
		}

		/// <summary>
		/// Resolves the given service by type and name, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			return ResolveCore<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4));
		}

		/// <summary>
		/// Resolves the given service by type and name, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			return ResolveCore<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4, arg5));
		}

		/// <summary>
		/// Resolves the given service by type and name, passing the given arguments 
		/// for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg6">Sixth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance.</returns>
		/// <exception cref="ResolutionException">The given service could not be resolved.</exception>
		public TService ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			return ResolveCore<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4, arg5, arg6));
		}

		#endregion

		#region TryResolve

		/// <summary>
		/// Attempts to resolve the given service by type, without passing arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolve<TService>()
		{
			return TryResolveNamed<TService>(null);
		}

		/// <summary>
		/// Attempts to resolve the given service by type, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolve<TService, TArg>(TArg arg)
		{
			return TryResolveNamed<TService, TArg>(null, arg);
		}

		/// <summary>
		/// Attempts to resolve the given service by type, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolve<TService, TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
		{
			return TryResolveNamed<TService, TArg1, TArg2>(null, arg1, arg2);
		}

		/// <summary>
		/// Attempts to resolve the given service by type, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolve<TService, TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			return TryResolveNamed<TService, TArg1, TArg2, TArg3>(null, arg1, arg2, arg3);
		}

		/// <summary>
		/// Attempts to resolve the given service by type, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolve<TService, TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			return TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4>(null, arg1, arg2, arg3, arg4);
		}

		/// <summary>
		/// Attempts to resolve the given service by type, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolve<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			return TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(null, arg1, arg2, arg3, arg4, arg5);
		}

		/// <summary>
		/// Attempts to resolve the given service by type, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg6">Sixth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolve<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			return TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(null, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		#endregion

		#region TryResolveNamed

		/// <summary>
		/// Attempts to resolve the given service by type and name, without passing 
		/// arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolveNamed<TService>(string name)
		{
			return TryResolveCore<TService, Func<Container, TService>>(
				name, f => f(this));
		}

		/// <summary>
		/// Attempts to resolve the given service by type and name, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolveNamed<TService, TArg>(string name, TArg arg)
		{
			return TryResolveCore<TService, Func<Container, TArg, TService>>(
				name, f => f(this, arg));
		}

		/// <summary>
		/// Attempts to resolve the given service by type and name, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolveNamed<TService, TArg1, TArg2>(string name, TArg1 arg1, TArg2 arg2)
		{
			return TryResolveCore<TService, Func<Container, TArg1, TArg2, TService>>(
				name, f => f(this, arg1, arg2));
		}

		/// <summary>
		/// Attempts to resolve the given service by type and name, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolveNamed<TService, TArg1, TArg2, TArg3>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			return TryResolveCore<TService, Func<Container, TArg1, TArg2, TArg3, TService>>(
				name, f => f(this, arg1, arg2, arg3));
		}

		/// <summary>
		/// Attempts to resolve the given service by type and name, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			return TryResolveCore<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4));
		}

		/// <summary>
		/// Attempts to resolve the given service by type and name, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			return TryResolveCore<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4, arg5));
		}

		/// <summary>
		/// Attempts to resolve the given service by type and name, passing the 
		/// given arguments arguments for its initialization.
		/// </summary>
		/// <typeparam name="TService">Type of the service to retrieve.</typeparam>
		/// <typeparam name="TArg1">First argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg2">Second argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg3">Third argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg4">Fourth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg5">Fifth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <typeparam name="TArg6">Sixth argument to pass to the factory delegate that may create the instace.</typeparam>
		/// <returns>The resolved service instance or <see langword="null"/> if it cannot be resolved.</returns>
		public TService TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			return TryResolveCore<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4, arg5, arg6));
		}

		#endregion

		private TService ResolveCore<TService, TFunc>(string name, Func<TFunc, TService> invoker)
		{
			return ResolveImpl<TService, TFunc>(name, invoker, true);
		}

		private TService TryResolveCore<TService, TFunc>(string name, Func<TFunc, TService> invoker)
		{
			return ResolveImpl<TService, TFunc>(name, invoker, false);
		}

		private TService ResolveImpl<TService, TFunc>(string name, Func<TFunc, TService> invoker, bool throwIfMissing)
		{
			var key = new ServiceKey(typeof(TService), typeof(TFunc), name);
			var entry = GetEntry(key);

			if (entry != null)
			{
				switch (entry.Reuse)
				{
					case ReuseScope.Hierarchy:
						if (entry.Instance == null)
						{
							if (entry.Container != this)
								return entry.Container.ResolveImpl<TService, TFunc>(name, invoker, throwIfMissing);
							else 
								entry.Instance = CreateInstance<TService, TFunc>(entry, invoker);
						}

						return (TService)entry.Instance;

					case ReuseScope.Container:
						ServiceEntry containerEntry;
						if (entry.Container != this)
						{
							// If the container for the registration entry is 
							// not the same as the current container, clone 
							// the entry and register locally on this container
							// for further resolutions.
							containerEntry = entry.CloneFor(this);
							this.Register(key, containerEntry);
						}
						else
						{
							containerEntry = entry;
						}

						if (containerEntry.Instance == null)
							containerEntry.Instance = CreateInstance<TService, TFunc>(containerEntry, invoker);

						return (TService)containerEntry.Instance;

					case ReuseScope.None:
						// Always creates a new instance.
						return CreateInstance<TService, TFunc>(entry, invoker);
					// We don't keep the instance with a strong reference on the 
					// ServiceEntry as it's not container or singleton-managed.

					default:
						throw new ResolutionException(Properties.Resources.ResolutionException_UnknownScope);
				}
			}

			if (throwIfMissing)
				return ThrowMissing<TService>(name);
			else
				return default(TService);
		}

		private TService CreateInstance<TService, TFunc>(ServiceEntry entry, Func<TFunc, TService> invoker)
		{
			var factory = (TFunc)entry.Factory;
			var instance = invoker(factory);
			// Track for disposal if necessary
			if (entry.Owner == Owner.Container && instance is IDisposable)
				disposables.Push(new WeakReference(instance));

			// Call initializer if necessary
			if (entry.Initializer != null)
				((Action<Container, TService>)entry.Initializer).Invoke(this, instance);

			return instance;
		}

		private ServiceEntry GetEntry(ServiceKey key)
		{
			ServiceEntry entry = null;
			// Go up the hierarchy always for registrations.
			if (!services.TryGetValue(key, out entry) && parentContainer != null)
				return parentContainer.GetEntry(key);
			else
				return entry;
		}

		private static TService ThrowMissing<TService>(string name)
		{
			if (name == null)
				throw new ResolutionException(typeof(TService));
			else
				throw new ResolutionException(typeof(TService), name);
		}
	}
}
