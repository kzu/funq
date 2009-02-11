using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Collections.Generic;

namespace Funq.Tests
{
	[TestClass]
	public class ContainerFixture
	{
		[TestMethod]
		public void ShouldRegister()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo());

			var container = builder.Build();

			var foo = container.Resolve<IFoo>();
		}

		[TestMethod]
		public void ThrowsIfCannotResolve()
		{
			var container = new Container();

			try
			{
				var foo = container.Resolve<IFoo>();
				Assert.Fail("Should have thrown ResolutionException");
			}
			catch (ResolutionException)
			{
			}
		}

		[TestMethod]
		public void ThrowsIfCannotResolveNamed()
		{
			var container = new Container();

			try
			{
				var foo = container.ResolveNamed<IFoo>("foo");
				Assert.Fail("Should have thrown ResolutionException");
			}
			catch (ResolutionException re)
			{
				Assert.IsTrue(re.Message.IndexOf("foo") != -1);
			}
		}

		[TestMethod]
		public void RegistersDelegateForType()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo());

			var container = builder.Build();

			var foo = container.Resolve<IFoo>();

			Assert.IsNotNull(foo);
			Assert.IsTrue(foo is IFoo);
			Assert.IsTrue(foo is Foo);
		}

		[TestMethod]
		public void RegistersNamedInstances()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo()).Named("foo");
			builder.Register<IFoo>(c => new Foo2()).Named("foo2");

			var container = builder.Build();

			var foo = container.ResolveNamed<IFoo>("foo");
			var foo2 = container.ResolveNamed<IFoo>("foo2");

			Assert.AreNotSame(foo, foo2);
			Assert.IsTrue(foo is IFoo);
			Assert.IsTrue(foo2 is IFoo);
			Assert.IsTrue(foo is Foo);
			Assert.IsTrue(foo2 is Foo2);
		}

		[TestMethod]
		public void RegistersWithCtorArguments()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo, string>((c, s) => new Foo(s));

			var container = builder.Build();

			var foo = container.Resolve<IFoo, string>("value");

			Assert.AreEqual("value", ((Foo)foo).Value);
		}

		[TestMethod]
		public void RegistersWithCtorOverloads()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo());
			builder.Register<IFoo, string>((c, s) => new Foo(s));
			builder.Register<IFoo, string, int>((c, s, i) => new Foo(s, i));
			var container = builder.Build();


			var foo = container.Resolve<IFoo, string>("value");
			var foo2 = container.Resolve<IFoo, string, int>("foo", 25);

			Assert.AreEqual("value", ((Foo)foo).Value);
			Assert.AreEqual("foo", ((Foo)foo2).Value);
			Assert.AreEqual(25, ((Foo)foo2).Count);
		}

		[TestMethod]
		public void RegistersAllOverloads()
		{
			var builder = new ContainerBuilder();

			builder.Register<Bar>(c => new Bar()).Named("bar");
			builder.Register<Bar, string>((c, s) => new Bar(s)).Named("bar");
			builder.Register<Bar, string, string>((c, s1, s2) => new Bar(s1, s2)).Named("bar");
			builder.Register<Bar, string, string, string>((c, s1, s2, s3) => new Bar(s1, s2, s3)).Named("bar");
			builder.Register<Bar, string, string, string, string>((c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4)).Named("bar");
			builder.Register<Bar, string, string, string, string, string>((c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5)).Named("bar");
			builder.Register<Bar, string, string, string, string, string, string>((c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6)).Named("bar");

			builder.Register<Bar>(c => new Bar());
			builder.Register<Bar, string>((c, s) => new Bar(s));
			builder.Register<Bar, string, string>((c, s1, s2) => new Bar(s1, s2));
			builder.Register<Bar, string, string, string>((c, s1, s2, s3) => new Bar(s1, s2, s3));
			builder.Register<Bar, string, string, string, string>((c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4));
			builder.Register<Bar, string, string, string, string, string>((c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5));
			builder.Register<Bar, string, string, string, string, string, string>((c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6));

			var container = builder.Build();

			Assert.IsNotNull(container.Resolve<Bar>());

			var b = container.Resolve<Bar, string>("a1");
			Assert.AreEqual("a1", b.Arg1);

			b = container.Resolve<Bar, string, string>("a1", "a2");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);

			b = container.Resolve<Bar, string, string, string>("a1", "a2", "a3");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);
			Assert.AreEqual("a3", b.Arg3);

			b = container.Resolve<Bar, string, string, string, string>("a1", "a2", "a3", "a4");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);
			Assert.AreEqual("a3", b.Arg3);
			Assert.AreEqual("a4", b.Arg4);

			b = container.Resolve<Bar, string, string, string, string, string>("a1", "a2", "a3", "a4", "a5");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);
			Assert.AreEqual("a3", b.Arg3);
			Assert.AreEqual("a4", b.Arg4);
			Assert.AreEqual("a5", b.Arg5);

			b = container.Resolve<Bar, string, string, string, string, string, string>("a1", "a2", "a3", "a4", "a5", "a6");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);
			Assert.AreEqual("a3", b.Arg3);
			Assert.AreEqual("a4", b.Arg4);
			Assert.AreEqual("a5", b.Arg5);
			Assert.AreEqual("a6", b.Arg6);


			Assert.IsNotNull(container.ResolveNamed<Bar>("bar"));

			b = container.ResolveNamed<Bar, string>("bar", "a1");
			Assert.AreEqual("a1", b.Arg1);

			b = container.ResolveNamed<Bar, string, string>("bar", "a1", "a2");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);

			b = container.ResolveNamed<Bar, string, string, string>("bar", "a1", "a2", "a3");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);
			Assert.AreEqual("a3", b.Arg3);

			b = container.ResolveNamed<Bar, string, string, string, string>("bar", "a1", "a2", "a3", "a4");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);
			Assert.AreEqual("a3", b.Arg3);
			Assert.AreEqual("a4", b.Arg4);

			b = container.ResolveNamed<Bar, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);
			Assert.AreEqual("a3", b.Arg3);
			Assert.AreEqual("a4", b.Arg4);
			Assert.AreEqual("a5", b.Arg5);

			b = container.ResolveNamed<Bar, string, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5", "a6");
			Assert.AreEqual("a1", b.Arg1);
			Assert.AreEqual("a2", b.Arg2);
			Assert.AreEqual("a3", b.Arg3);
			Assert.AreEqual("a4", b.Arg4);
			Assert.AreEqual("a5", b.Arg5);
			Assert.AreEqual("a6", b.Arg6);
		}

		[TestMethod]
		public void RegisterOrderForNamedDoesNotMatter()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo());
			builder.Register<IFoo>(c => new Foo("foo")).Named("foo");
			var container = builder.Build();


			var foo = container.Resolve<IFoo>();
			var foo2 = container.ResolveNamed<IFoo>("foo");

			Assert.IsNotNull(foo);
			Assert.IsNotNull(foo2);

			Assert.AreEqual("foo", ((Foo)foo2).Value);
		}

		[TestMethod]
		public void TryResolveReturnsNullIfNotRegistered()
		{
			var container = new Container();

			Assert.IsNull(container.TryResolve<IFoo>());
			Assert.IsNull(container.TryResolve<IFoo, string>("a1"));
			Assert.IsNull(container.TryResolve<IFoo, string, string>("a1", "a2"));
			Assert.IsNull(container.TryResolve<IFoo, string, string, string>("a1", "a2", "a3"));
			Assert.IsNull(container.TryResolve<IFoo, string, string, string, string>("a1", "a2", "a3", "a4"));
			Assert.IsNull(container.TryResolve<IFoo, string, string, string, string, string>("a1", "a2", "a3", "a4", "a5"));
			Assert.IsNull(container.TryResolve<IFoo, string, string, string, string, string, string>("a1", "a2", "a3", "a4", "a5", "a6"));
		}

		[TestMethod]
		public void TryResolveNamedReturnsNullIfNotRegistered()
		{
			var container = new Container();

			Assert.IsNull(container.TryResolveNamed<IFoo>("foo"));
			Assert.IsNull(container.TryResolveNamed<IFoo, string>("foo", "a1"));
			Assert.IsNull(container.TryResolveNamed<IFoo, string, string>("foo", "a1", "a2"));
			Assert.IsNull(container.TryResolveNamed<IFoo, string, string, string>("foo", "a1", "a2", "a3"));
			Assert.IsNull(container.TryResolveNamed<IFoo, string, string, string, string>("foo", "a1", "a2", "a3", "a4"));
			Assert.IsNull(container.TryResolveNamed<IFoo, string, string, string, string, string>("foo", "a1", "a2", "a3", "a4", "a5"));
			Assert.IsNull(container.TryResolveNamed<IFoo, string, string, string, string, string, string>("foo", "a1", "a2", "a3", "a4", "a5", "a6"));
		}

		[TestMethod]
		public void TryResolveReturnsRegisteredInstance()
		{
			var builder = new ContainerBuilder();

			builder.Register<Bar>(c => new Bar()).Named("bar");
			builder.Register<Bar, string>((c, s) => new Bar(s)).Named("bar");
			builder.Register<Bar, string, string>((c, s1, s2) => new Bar(s1, s2)).Named("bar");
			builder.Register<Bar, string, string, string>((c, s1, s2, s3) => new Bar(s1, s2, s3)).Named("bar");
			builder.Register<Bar, string, string, string, string>((c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4)).Named("bar");
			builder.Register<Bar, string, string, string, string, string>((c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5)).Named("bar");
			builder.Register<Bar, string, string, string, string, string, string>((c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6)).Named("bar");

			var container = builder.Build();

			Assert.IsNotNull(container.TryResolveNamed<Bar>("bar"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string>("bar", "a1"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string>("bar", "a1", "a2"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string, string>("bar", "a1", "a2", "a3"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string, string, string>("bar", "a1", "a2", "a3", "a4"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5", "a6"));
		}

		[TestMethod]
		public void TryResolveReturnsRegisteredInstanceOnParent()
		{
			var builder = new ContainerBuilder();

			builder.Register<Bar>(c => new Bar()).Named("bar");
			builder.Register<Bar, string>((c, s) => new Bar(s)).Named("bar");
			builder.Register<Bar, string, string>((c, s1, s2) => new Bar(s1, s2)).Named("bar");
			builder.Register<Bar, string, string, string>((c, s1, s2, s3) => new Bar(s1, s2, s3)).Named("bar");
			builder.Register<Bar, string, string, string, string>((c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4)).Named("bar");
			builder.Register<Bar, string, string, string, string, string>((c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5)).Named("bar");
			builder.Register<Bar, string, string, string, string, string, string>((c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6)).Named("bar");

			var container = builder.Build().CreateChildContainer();

			Assert.IsNotNull(container.TryResolveNamed<Bar>("bar"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string>("bar", "a1"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string>("bar", "a1", "a2"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string, string>("bar", "a1", "a2", "a3"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string, string, string>("bar", "a1", "a2", "a3", "a4"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5"));
			Assert.IsNotNull(container.TryResolveNamed<Bar, string, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5", "a6"));
		}

		[TestMethod]
		public void LatestRegistrationOverridesPrevious()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo());
			builder.Register<IFoo>(c => new Foo("foo"));
			var container = builder.Build();

			var foo = container.Resolve<IFoo>();

			Assert.AreEqual("foo", ((Foo)foo).Value);
		}

		[TestMethod]
		public void DisposesContainerOwnedInstances()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable()).OwnedBy(Owner.Container);
			builder.Register<IBase>(c => new Disposable()).OwnedBy(Owner.External);

			var container = builder.Build();

			var containerOwned = container.Resolve<IFoo>() as Disposable;
			var externallyOwned = container.Resolve<IBase>() as Disposable;

			container.Dispose();

			Assert.IsTrue(containerOwned.IsDisposed);
			Assert.IsFalse(externallyOwned.IsDisposed);
		}

		[TestMethod]
		public void ChildContainerCanReuseRegistrationsOnParent()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo());
			var container = builder.Build();
			var child = container.CreateChildContainer();

			var foo = child.Resolve<IFoo>();

			Assert.IsNotNull(foo);
		}

		[TestMethod]
		public void NoReuseCreatesNewInstancesAlways()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.None);
			var container = builder.Build();

			var foo1 = container.Resolve<IFoo>();
			var foo2 = container.Resolve<IFoo>();

			Assert.IsNotNull(foo1);
			Assert.IsNotNull(foo2);
			Assert.AreNotSame(foo1, foo2);
		}

		[TestMethod]
		public void ThrowsIfUnknownReuseScope()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo()).ReusedWithin((ReuseScope)5);
			var container = builder.Build();

			try
			{
				var foo1 = container.Resolve<IFoo>();
				Assert.Fail("Should have thrown ResolutionException because of unkown scope.");
			}
			catch (ResolutionException)
			{
			}
		}

		[TestMethod]
		public void ContainerScopedInstanceIsReused()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Container);
			var container = builder.Build();

			var foo1 = container.Resolve<IFoo>();
			var foo2 = container.Resolve<IFoo>();

			Assert.IsNotNull(foo1);
			Assert.IsNotNull(foo2);
			Assert.AreSame(foo1, foo2);
		}

		[TestMethod]
		public void HierarchyScopedInstanceIsReusedOnSameContainer()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Hierarchy);
			var container = builder.Build();

			var foo1 = container.Resolve<IFoo>();
			var foo2 = container.Resolve<IFoo>();

			Assert.IsNotNull(foo1);
			Assert.IsNotNull(foo2);
			Assert.AreSame(foo1, foo2);
		}

		[TestMethod]
		public void HierarchyScopedInstanceIsReusedFromParentContainer()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Hierarchy);
			var parent = builder.Build();
			var child = parent.CreateChildContainer();

			var foo1 = parent.Resolve<IFoo>();
			var foo2 = child.Resolve<IFoo>();

			Assert.IsNotNull(foo1);
			Assert.IsNotNull(foo2);
			Assert.AreSame(foo1, foo2);
		}

		[TestMethod]
		public void HierarchyScopedInstanceIsCreatedOnRegistrationContainer()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable()).ReusedWithin(ReuseScope.Hierarchy);
			var parent = builder.Build();
			var child = parent.CreateChildContainer();

			var childFoo = child.Resolve<IFoo>() as Disposable;
			var parentFoo = parent.Resolve<IFoo>() as Disposable;

			Assert.IsNotNull(parentFoo);
			Assert.IsNotNull(childFoo);

			child.Dispose();

			Assert.IsFalse(parentFoo.IsDisposed);
		}

		[TestMethod]
		public void ContainerScopedInstanceIsNotReusedFromParentContainer()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Container);
			var parent = builder.Build();
			var child = parent.CreateChildContainer();

			var foo1 = parent.Resolve<IFoo>();
			var foo2 = child.Resolve<IFoo>();

			Assert.IsNotNull(foo1);
			Assert.IsNotNull(foo2);
			Assert.AreNotSame(foo1, foo2);
		}

		[TestMethod]
		public void DisposingParentContainerDisposesChildContainerAndInstances()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable()).ReusedWithin(ReuseScope.Hierarchy);
			builder.Register<IBase>(c => new Disposable()).ReusedWithin(ReuseScope.Container);
			var parent = builder.Build();
			var child = parent.CreateChildContainer();

			var parentFoo = parent.Resolve<IFoo>() as Disposable;
			var childFoo = child.Resolve<IBase>() as Disposable;

			parent.Dispose();

			Assert.IsTrue(parentFoo.IsDisposed);
			Assert.IsTrue(childFoo.IsDisposed);
		}

		[TestMethod]
		public void ContainerOwnedNonReuseInstacesAreDisposed()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable())
				.ReusedWithin(ReuseScope.None)
				.OwnedBy(Owner.Container);

			var container = builder.Build();

			var foo = container.Resolve<IFoo>() as Disposable;

			container.Dispose();

			Assert.IsTrue(foo.IsDisposed);
		}

		[TestMethod]
		public void ContainerOwnedNonReuseInstacesAreNotKeptAlive()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable())
				.ReusedWithin(ReuseScope.None)
				.OwnedBy(Owner.Container);

			var container = builder.Build();

			var foo = container.Resolve<IFoo>() as Disposable;
			var wr = new WeakReference(foo);

			foo = null;

			GC.Collect();

			Assert.IsFalse(wr.IsAlive);
		}

		[TestMethod]
		public void ContainerOwnedAndContainerReusedInstacesAreDisposed()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable())
				.ReusedWithin(ReuseScope.Container)
				.OwnedBy(Owner.Container);

			var container = builder.Build();

			var foo = container.Resolve<IFoo>() as Disposable;

			container.Dispose();

			Assert.IsTrue(foo.IsDisposed);
		}

		[TestMethod]
		public void ContainerOwnedAndHierarchyReusedInstacesAreDisposed()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable())
				.ReusedWithin(ReuseScope.Hierarchy)
				.OwnedBy(Owner.Container);

			var container = builder.Build();

			var foo = container.Resolve<IFoo>() as Disposable;

			container.Dispose();

			Assert.IsTrue(foo.IsDisposed);
		}

		[TestMethod]
		public void ChildContainerInstanceWithParentRegistrationIsDisposed()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable())
				.ReusedWithin(ReuseScope.Hierarchy)
				.OwnedBy(Owner.Container);

			var parent = builder.Build();
			var child = parent.CreateChildContainer();

			var foo = child.Resolve<IFoo>() as Disposable;

			child.Dispose();

			Assert.IsFalse(foo.IsDisposed);
		}

		[TestMethod]
		public void DisposingParentContainerDisposesChildContainerInstances()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable())
				.ReusedWithin(ReuseScope.None)
				.OwnedBy(Owner.Container);

			var parent = builder.Build();
			var child = parent.CreateChildContainer();

			var foo = child.Resolve<IFoo>() as Disposable;

			parent.Dispose();

			Assert.IsTrue(foo.IsDisposed);
		}

		[TestMethod]
		public void DisposingContainerDoesNotDisposeExternalOwnedInstances()
		{
			var builder = new ContainerBuilder();
			builder.Register<IFoo>(c => new Disposable())
				.ReusedWithin(ReuseScope.Hierarchy)
				.OwnedBy(Owner.External);

			var container = builder.Build();

			var foo = container.Resolve<IFoo>() as Disposable;

			container.Dispose();

			Assert.IsFalse(foo.IsDisposed);
		}

		[TestMethod]
		public void InitializerCalledWhenInstanceCreated()
		{
			var builder = new ContainerBuilder();
			builder
				.Register<IInitializable>(c => new Initializable())
				.InitializedBy((c, i) => i.Initialize());

			var container = builder.Build();
			
			var i1 = container.Resolve<IInitializable>() as Initializable;
			var i2 = container.Resolve<IInitializable>() as Initializable;

			Assert.AreSame(i1, i2);
			Assert.AreEqual(1, i1.InitializeCalls);
		}

		public class Disposable : IFoo, IDisposable
		{
			public bool IsDisposed;
			public void Dispose()
			{
				IsDisposed = true;
			}
		}

		public interface IInitializable { void Initialize(); }
		public class Initializable : IInitializable
		{
			public int InitializeCalls;

			public void Initialize()
			{
				InitializeCalls++;
			}
		}

		public interface IBase { }
		public interface IFoo : IBase { }

		public class Foo : IFoo
		{
			public Foo() { }
			public Foo(string s) { Value = s; }
			public Foo(string s, int c) { Value = s; Count = c; }
			public string Value { get; set; }
			public int Count { get; set; }
		}

		public class Foo2 : IFoo { }

		public class Bar
		{
			public Bar()
			{
			}

			public Bar(string arg1)
			{
				this.Arg1 = arg1;
			}

			public Bar(string arg1, string arg2)
			{
				this.Arg1 = arg1;
				this.Arg2 = arg2;
			}

			public Bar(string arg1, string arg2, string arg3)
			{
				this.Arg1 = arg1;
				this.Arg2 = arg2;
				this.Arg3 = arg3;
			}

			public Bar(string arg1, string arg2, string arg3, string arg4)
			{
				this.Arg1 = arg1;
				this.Arg2 = arg2;
				this.Arg3 = arg3;
				this.Arg4 = arg4;
			}

			public Bar(string arg1, string arg2, string arg3, string arg4, string arg5)
			{
				this.Arg1 = arg1;
				this.Arg2 = arg2;
				this.Arg3 = arg3;
				this.Arg4 = arg4;
				this.Arg5 = arg5;
			}

			public Bar(string arg1, string arg2, string arg3, string arg4, string arg5, string arg6)
			{
				this.Arg1 = arg1;
				this.Arg2 = arg2;
				this.Arg3 = arg3;
				this.Arg4 = arg4;
				this.Arg5 = arg5;
				this.Arg6 = arg6;
			}

			public string Arg1 { get; set; }
			public string Arg2 { get; set; }
			public string Arg3 { get; set; }
			public string Arg4 { get; set; }
			public string Arg5 { get; set; }
			public string Arg6 { get; set; }
		}
	}
}
