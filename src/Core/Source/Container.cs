using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Funq
{
	/// <include file='Container.xdoc' path='docs/doc[@for="Container"]/*'/>
	public sealed class Container : IDisposable
	{
		Dictionary<ServiceKey, ServiceEntry> services = new Dictionary<ServiceKey, ServiceEntry>();
		// Disposable components include factory-scoped instances that we don't keep 
		// a strong reference to. 
		Stack<WeakReference> disposables = new Stack<WeakReference>();
		// We always hold a strong reference to child containers.
		Stack<Container> childContainers = new Stack<Container>();
		Container parentContainer;

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.ctor"]/*'/>
		public Container()
		{
			services[new ServiceKey(typeof(Container), typeof(Func<Container, Container>), null)] =
				new ServiceEntry<Container>((Func<Container, Container>)(c => c))
				{
					Container = this,
					Instance = this,
					Owner = Owner.External,
					Reuse = ReuseScope.Container,
				};
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.DefaultOwner"]/*'/>
		public Owner DefaultOwner { get; set; }

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.DefaultReuse"]/*'/>
		public ReuseScope DefaultReuse { get; set; }

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.CreateChildContainer"]/*'/>
		public Container CreateChildContainer()
		{
			var child = new Container { parentContainer = this };
			childContainers.Push(child);
			return child;
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Dispose"]/*'/>
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

		private ServiceEntry<TService> RegisterImpl<TService, TFunc>(string name, TFunc factory)
		{
			if (typeof(TService) == typeof(Container))
				throw new ArgumentException(Properties.Resources.Registration_CantRegisterContainer);

			var entry = new ServiceEntry<TService>(factory)
			{
				Container = this,
				Reuse = DefaultReuse,
				Owner = DefaultOwner
			};
			var key = new ServiceKey(typeof(TService), typeof(TFunc), name);

			services[key] = entry;

			return entry;
		}

		private TService ResolveImpl<TService, TFunc>(string name, Func<TFunc, TService> invoker, bool throwIfMissing)
		{
			var key = new ServiceKey(typeof(TService), typeof(TFunc), name);
			var entry = GetEntry<TService>(key);

			if (entry != null)
			{
				switch (entry.Reuse)
				{
					case ReuseScope.Container:
						if (entry.Container != this)
						{
							// If the container for the registration entry is 
							// not the same as the current container, clone 
							// the entry and register locally on this container
							// for further resolutions.
							entry = entry.CloneFor(this);
							services[key] = entry;
						}
						break;

					case ReuseScope.Hierarchy:
					case ReuseScope.None:
						// Nothing special to do in this case
						break;

					default:
						throw new ResolutionException(Properties.Resources.ResolutionException_UnknownScope);
				}

				if (entry.Instance == null)
				{
					return CreateAndInitializeInstance(entry, invoker);
				}

				return entry.Instance;
			}

			if (throwIfMissing)
				return ThrowMissing<TService>(name);
			else
				return default(TService);
		}

		private TService CreateAndInitializeInstance<TService, TFunc>(ServiceEntry<TService> entry, Func<TFunc, TService> invoker)
		{
			var factory = (TFunc)entry.Factory;
			var instance = invoker(factory);

			// Save instance if Hierarchy or Container Reuse 
			if (entry.Reuse != ReuseScope.None)
				entry.Instance = instance;

			// Track for disposal if necessary
			if (entry.Owner == Owner.Container && instance is IDisposable)
				entry.Container.disposables.Push(new WeakReference(instance));

			// Call initializer if necessary
			if (entry.Initializer != null)
				entry.Initializer(entry.Container, instance);

			return instance;
		}

		private ServiceEntry<TService> GetEntry<TService>(ServiceKey key)
		{
			ServiceEntry entry = null;
			// Go up the hierarchy always for registrations.

			Container container = this;
			while (!container.services.TryGetValue(key, out entry) && container.parentContainer != null)
			{
				container = container.parentContainer;
			}

			return (ServiceEntry<TService>)entry;
		}

		private static TService ThrowMissing<TService>(string name)
		{
			if (name == null)
				throw new ResolutionException(typeof(TService));
			else
				throw new ResolutionException(typeof(TService), name);
		}

		/* The following regions contain just the typed overloads
		 * that are just pass-through to the real implementations.
		 * They all have DebuggerStepThrough to ease debugging. */

		#region Register

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService}(factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService>(Func<Container, TService> factory)
		{
			return Register(null, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg}(factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg>(Func<Container, TArg, TService> factory)
		{
			return Register(null, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2}(factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2>(Func<Container, TArg1, TArg2, TService> factory)
		{
			return Register(null, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2,TArg3}(factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3>(Func<Container, TArg1, TArg2, TArg3, TService> factory)
		{
			return Register(null, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2,TArg3,TArg4}(factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3, TArg4>(Func<Container, TArg1, TArg2, TArg3, TArg4, TService> factory)
		{
			return Register(null, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2,TArg3,TArg4,TArg5}(factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TService> factory)
		{
			return Register(null, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2,TArg3,TArg4,TArg5,TArg6}(factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService> factory)
		{
			return Register(null, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService}(name,factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService>(string name, Func<Container, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TService>>(name, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg}(name,factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg>(string name, Func<Container, TArg, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg, TService>>(name, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2}(name,factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2>(string name, Func<Container, TArg1, TArg2, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TService>>(name, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2,TArg3}(name,factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3>(string name, Func<Container, TArg1, TArg2, TArg3, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TArg3, TService>>(name, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2,TArg3,TArg4}(name,factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3, TArg4>(string name, Func<Container, TArg1, TArg2, TArg3, TArg4, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TService>>(name, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2,TArg3,TArg4,TArg5}(name,factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(name, factory);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Register{TService,TArg1,TArg2,TArg3,TArg4,TArg5,TArg6}(name,factory)"]/*'/>
		[DebuggerStepThrough]
		public IRegistration<TService> Register<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService> factory)
		{
			return RegisterImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(name, factory);
		}

		#endregion

		#region Resolve

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Resolve{TService}"]/*'/>
		[DebuggerStepThrough]
		public TService Resolve<TService>()
		{
			return ResolveNamed<TService>(null);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Resolve{TService,TArg}"]/*'/>
		[DebuggerStepThrough]
		public TService Resolve<TService, TArg>(TArg arg)
		{
			return ResolveNamed<TService, TArg>(null, arg);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Resolve{TService,TArg1,TArg2}"]/*'/>
		[DebuggerStepThrough]
		public TService Resolve<TService, TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
		{
			return ResolveNamed<TService, TArg1, TArg2>(null, arg1, arg2);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Resolve{TService,TArg1,TArg2,TArg3}"]/*'/>
		[DebuggerStepThrough]
		public TService Resolve<TService, TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			return ResolveNamed<TService, TArg1, TArg2, TArg3>(null, arg1, arg2, arg3);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Resolve{TService,TArg1,TArg2,TArg3,TArg4}"]/*'/>
		[DebuggerStepThrough]
		public TService Resolve<TService, TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			return ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4>(null, arg1, arg2, arg3, arg4);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Resolve{TService,TArg1,TArg2,TArg3,TArg4,TArg5}"]/*'/>
		[DebuggerStepThrough]
		public TService Resolve<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			return ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(null, arg1, arg2, arg3, arg4, arg5);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.Resolve{TService,TArg1,TArg2,TArg3,TArg4,TArg5,TArg6}"]/*'/>
		[DebuggerStepThrough]
		public TService Resolve<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			return ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(null, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		#endregion

		#region ResolveNamed

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.ResolveNamed{TService}"]/*'/>
		[DebuggerStepThrough]
		public TService ResolveNamed<TService>(string name)
		{
			return ResolveImpl<TService, Func<Container, TService>>(
				name, f => f(this), true);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.ResolveNamed{TService,TArg}"]/*'/>
		[DebuggerStepThrough]
		public TService ResolveNamed<TService, TArg>(string name, TArg arg)
		{
			return ResolveImpl<TService, Func<Container, TArg, TService>>(
				name, f => f(this, arg), true);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.ResolveNamed{TService,TArg1,TArg2}"]/*'/>
		[DebuggerStepThrough]
		public TService ResolveNamed<TService, TArg1, TArg2>(string name, TArg1 arg1, TArg2 arg2)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TService>>(
				name, f => f(this, arg1, arg2), true);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.ResolveNamed{TService,TArg1,TArg2,TArg3}"]/*'/>
		[DebuggerStepThrough]
		public TService ResolveNamed<TService, TArg1, TArg2, TArg3>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TArg3, TService>>(
				name, f => f(this, arg1, arg2, arg3), true);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.ResolveNamed{TService,TArg1,TArg2,TArg3,TArg4}"]/*'/>
		[DebuggerStepThrough]
		public TService ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4), true);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.ResolveNamed{TService,TArg1,TArg2,TArg3,TArg4,TArg5}"]/*'/>
		[DebuggerStepThrough]
		public TService ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4, arg5), true);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.ResolveNamed{TService,TArg1,TArg2,TArg3,TArg4,TArg5,TArg6}"]/*'/>
		[DebuggerStepThrough]
		public TService ResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4, arg5, arg6), true);
		}

		#endregion

		#region TryResolve

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolve{TService}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolve<TService>()
		{
			return TryResolveNamed<TService>(null);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolve{TService,TArg}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolve<TService, TArg>(TArg arg)
		{
			return TryResolveNamed<TService, TArg>(null, arg);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolve{TService,TArg1,TArg2}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolve<TService, TArg1, TArg2>(TArg1 arg1, TArg2 arg2)
		{
			return TryResolveNamed<TService, TArg1, TArg2>(null, arg1, arg2);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolve{TService,TArg1,TArg2,TArg3}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolve<TService, TArg1, TArg2, TArg3>(TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			return TryResolveNamed<TService, TArg1, TArg2, TArg3>(null, arg1, arg2, arg3);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolve{TService,TArg1,TArg2,TArg3,TArg4}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolve<TService, TArg1, TArg2, TArg3, TArg4>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			return TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4>(null, arg1, arg2, arg3, arg4);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolve{TService,TArg1,TArg2,TArg3,TArg4,TArg5}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolve<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			return TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(null, arg1, arg2, arg3, arg4, arg5);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolve{TService,TArg1,TArg2,TArg3,TArg4,TArg5,TArg6}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolve<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			return TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(null, arg1, arg2, arg3, arg4, arg5, arg6);
		}

		#endregion

		#region TryResolveNamed

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolveNamed{TService}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolveNamed<TService>(string name)
		{
			return ResolveImpl<TService, Func<Container, TService>>(
				name, f => f(this), false);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolveNamed{TService,TArg}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolveNamed<TService, TArg>(string name, TArg arg)
		{
			return ResolveImpl<TService, Func<Container, TArg, TService>>(
				name, f => f(this, arg), false);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolveNamed{TService,TArg1,TArg2}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolveNamed<TService, TArg1, TArg2>(string name, TArg1 arg1, TArg2 arg2)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TService>>(
				name, f => f(this, arg1, arg2), false);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolveNamed{TService,TArg1,TArg2,TArg3}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolveNamed<TService, TArg1, TArg2, TArg3>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TArg3, TService>>(
				name, f => f(this, arg1, arg2, arg3), false);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolveNamed{TService,TArg1,TArg2,TArg3,TArg4}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4), false);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolveNamed{TService,TArg1,TArg2,TArg3,TArg4,TArg5}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4, arg5), false);
		}

		/// <include file='Container.xdoc' path='docs/doc[@for="Container.TryResolveNamed{TService,TArg1,TArg2,TArg3,TArg4,TArg5,TArg6}"]/*'/>
		[DebuggerStepThrough]
		public TService TryResolveNamed<TService, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(string name, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5, TArg6 arg6)
		{
			return ResolveImpl<TService, Func<Container, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TService>>(
				name, f => f(this, arg1, arg2, arg3, arg4, arg5, arg6), false);
		}

		#endregion
	}
}
