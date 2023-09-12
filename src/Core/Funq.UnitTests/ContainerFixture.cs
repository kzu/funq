using System;
using System.Diagnostics;

namespace Funq.Tests
{
    public class ContainerFixture
    {
        [Fact]
        public void ShouldRegister()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo());

            var foo = container.Resolve<IFoo>();
        }

        [Fact]
        public void RegisteredInstanceIsResolved()
        {
            var container = new Container();

            var f1 = new Foo();
            container.Register<IFoo>(f1);

            var f2 = container.Resolve<IFoo>();

            Assert.Equal(f1, f2);
        }

        [Fact]
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

        [Fact]
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
                Assert.True(re.Message.IndexOf("foo") != -1);
            }
        }

        [Fact]
        public void RegistersDelegateForType()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo());

            var foo = container.Resolve<IFoo>();

            Assert.NotNull(foo);
            Assert.True(foo is IFoo);
            Assert.True(foo is Foo);
        }

        [Fact]
        public void RegistersNamedInstances()
        {
            var container = new Container();
            container.Register<IFoo>("foo", c => new Foo());
            container.Register<IFoo>("foo2", c => new Foo2());

            var foo = container.ResolveNamed<IFoo>("foo");
            var foo2 = container.ResolveNamed<IFoo>("foo2");

            Assert.NotSame(foo, foo2);
            Assert.True(foo is IFoo);
            Assert.True(foo2 is IFoo);
            Assert.True(foo is Foo);
            Assert.True(foo2 is Foo2);
        }

        [Fact]
        public void RegistersWithCtorArguments()
        {
            var container = new Container();
            container.Register<IFoo, string>((c, s) => new Foo(s));

            var foo = container.Resolve<IFoo, string>("value");

            Assert.Equal("value", ((Foo)foo).Value);
        }

        [Fact]
        public void RegistersWithCtorOverloads()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo());
            container.Register<IFoo, string>((c, s) => new Foo(s));
            container.Register<IFoo, string, int>((c, s, i) => new Foo(s, i));

            var foo = container.Resolve<IFoo, string>("value");
            var foo2 = container.Resolve<IFoo, string, int>("foo", 25);

            Assert.Equal("value", ((Foo)foo).Value);
            Assert.Equal("foo", ((Foo)foo2).Value);
            Assert.Equal(25, ((Foo)foo2).Count);
        }

        [Fact]
        public void RegistersAllOverloads()
        {
            var container = new Container();

            container.Register<Bar>("bar", c => new Bar());
            container.Register<Bar, string>("bar", (c, s) => new Bar(s));
            container.Register<Bar, string, string>("bar", (c, s1, s2) => new Bar(s1, s2));
            container.Register<Bar, string, string, string>("bar", (c, s1, s2, s3) => new Bar(s1, s2, s3));
            container.Register<Bar, string, string, string, string>("bar", (c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4));
            container.Register<Bar, string, string, string, string, string>("bar", (c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5));
            container.Register<Bar, string, string, string, string, string, string>("bar", (c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6));

            container.Register<Bar>(c => new Bar());
            container.Register<Bar, string>((c, s) => new Bar(s));
            container.Register<Bar, string, string>((c, s1, s2) => new Bar(s1, s2));
            container.Register<Bar, string, string, string>((c, s1, s2, s3) => new Bar(s1, s2, s3));
            container.Register<Bar, string, string, string, string>((c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4));
            container.Register<Bar, string, string, string, string, string>((c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5));
            container.Register<Bar, string, string, string, string, string, string>((c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6));

            Assert.NotNull(container.Resolve<Bar>());

            var b = container.Resolve<Bar, string>("a1");
            Assert.Equal("a1", b.Arg1);

            b = container.Resolve<Bar, string, string>("a1", "a2");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);

            b = container.Resolve<Bar, string, string, string>("a1", "a2", "a3");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);

            b = container.Resolve<Bar, string, string, string, string>("a1", "a2", "a3", "a4");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);

            b = container.Resolve<Bar, string, string, string, string, string>("a1", "a2", "a3", "a4", "a5");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);
            Assert.Equal("a5", b.Arg5);

            b = container.Resolve<Bar, string, string, string, string, string, string>("a1", "a2", "a3", "a4", "a5", "a6");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);
            Assert.Equal("a5", b.Arg5);
            Assert.Equal("a6", b.Arg6);


            Assert.NotNull(container.ResolveNamed<Bar>("bar"));

            b = container.ResolveNamed<Bar, string>("bar", "a1");
            Assert.Equal("a1", b.Arg1);

            b = container.ResolveNamed<Bar, string, string>("bar", "a1", "a2");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);

            b = container.ResolveNamed<Bar, string, string, string>("bar", "a1", "a2", "a3");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);

            b = container.ResolveNamed<Bar, string, string, string, string>("bar", "a1", "a2", "a3", "a4");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);

            b = container.ResolveNamed<Bar, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);
            Assert.Equal("a5", b.Arg5);

            b = container.ResolveNamed<Bar, string, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5", "a6");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);
            Assert.Equal("a5", b.Arg5);
            Assert.Equal("a6", b.Arg6);
        }

        [Fact]
        public void RegisterOrderForNamedDoesNotMatter()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo());
            container.Register<IFoo>("foo", c => new Foo("foo"));

            var foo = container.Resolve<IFoo>();
            var foo2 = container.ResolveNamed<IFoo>("foo");

            Assert.NotNull(foo);
            Assert.NotNull(foo2);

            Assert.Equal("foo", ((Foo)foo2).Value);
        }

        [Fact]
        public void TryResolveReturnsNullIfNotRegistered()
        {
            var container = new Container();

            Assert.Null(container.TryResolve<IFoo>());
            Assert.Null(container.TryResolve<IFoo, string>("a1"));
            Assert.Null(container.TryResolve<IFoo, string, string>("a1", "a2"));
            Assert.Null(container.TryResolve<IFoo, string, string, string>("a1", "a2", "a3"));
            Assert.Null(container.TryResolve<IFoo, string, string, string, string>("a1", "a2", "a3", "a4"));
            Assert.Null(container.TryResolve<IFoo, string, string, string, string, string>("a1", "a2", "a3", "a4", "a5"));
            Assert.Null(container.TryResolve<IFoo, string, string, string, string, string, string>("a1", "a2", "a3", "a4", "a5", "a6"));
        }

        [Fact]
        public void TryResolveNamedReturnsNullIfNotRegistered()
        {
            var container = new Container();

            Assert.Null(container.TryResolveNamed<IFoo>("foo"));
            Assert.Null(container.TryResolveNamed<IFoo, string>("foo", "a1"));
            Assert.Null(container.TryResolveNamed<IFoo, string, string>("foo", "a1", "a2"));
            Assert.Null(container.TryResolveNamed<IFoo, string, string, string>("foo", "a1", "a2", "a3"));
            Assert.Null(container.TryResolveNamed<IFoo, string, string, string, string>("foo", "a1", "a2", "a3", "a4"));
            Assert.Null(container.TryResolveNamed<IFoo, string, string, string, string, string>("foo", "a1", "a2", "a3", "a4", "a5"));
            Assert.Null(container.TryResolveNamed<IFoo, string, string, string, string, string, string>("foo", "a1", "a2", "a3", "a4", "a5", "a6"));
        }

        [Fact]
        public void TryResolveReturnsRegisteredInstance()
        {
            var container = new Container();

            container.Register<Bar>("bar", c => new Bar());
            container.Register<Bar, string>("bar", (c, s) => new Bar(s));
            container.Register<Bar, string, string>("bar", (c, s1, s2) => new Bar(s1, s2));
            container.Register<Bar, string, string, string>("bar", (c, s1, s2, s3) => new Bar(s1, s2, s3));
            container.Register<Bar, string, string, string, string>("bar", (c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4));
            container.Register<Bar, string, string, string, string, string>("bar", (c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5));
            container.Register<Bar, string, string, string, string, string, string>("bar", (c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6));

            Assert.NotNull(container.TryResolveNamed<Bar>("bar"));
            Assert.NotNull(container.TryResolveNamed<Bar, string>("bar", "a1"));
            Assert.NotNull(container.TryResolveNamed<Bar, string, string>("bar", "a1", "a2"));
            Assert.NotNull(container.TryResolveNamed<Bar, string, string, string>("bar", "a1", "a2", "a3"));
            Assert.NotNull(container.TryResolveNamed<Bar, string, string, string, string>("bar", "a1", "a2", "a3", "a4"));
            Assert.NotNull(container.TryResolveNamed<Bar, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5"));
            Assert.NotNull(container.TryResolveNamed<Bar, string, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5", "a6"));
        }

        [Fact]
        public void TryResolveReturnsRegisteredInstanceOnParent()
        {
            var container = new Container();

            container.Register<Bar>("bar", c => new Bar());
            container.Register<Bar, string>("bar", (c, s) => new Bar(s));
            container.Register<Bar, string, string>("bar", (c, s1, s2) => new Bar(s1, s2));
            container.Register<Bar, string, string, string>("bar", (c, s1, s2, s3) => new Bar(s1, s2, s3));
            container.Register<Bar, string, string, string, string>("bar", (c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4));
            container.Register<Bar, string, string, string, string, string>("bar", (c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5));
            container.Register<Bar, string, string, string, string, string, string>("bar", (c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6));

            var child = container.CreateChildContainer();

            Assert.NotNull(child.TryResolveNamed<Bar>("bar"));
            Assert.NotNull(child.TryResolveNamed<Bar, string>("bar", "a1"));
            Assert.NotNull(child.TryResolveNamed<Bar, string, string>("bar", "a1", "a2"));
            Assert.NotNull(child.TryResolveNamed<Bar, string, string, string>("bar", "a1", "a2", "a3"));
            Assert.NotNull(child.TryResolveNamed<Bar, string, string, string, string>("bar", "a1", "a2", "a3", "a4"));
            Assert.NotNull(child.TryResolveNamed<Bar, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5"));
            Assert.NotNull(child.TryResolveNamed<Bar, string, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5", "a6"));
        }

        [Fact]
        public void LatestRegistrationOverridesPrevious()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo());
            container.Register<IFoo>(c => new Foo("foo"));

            var foo = container.Resolve<IFoo>();

            Assert.Equal("foo", ((Foo)foo).Value);
        }

        [Fact]
        public void DisposesContainerOwnedInstances()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Disposable()).OwnedBy(Owner.Container);
            container.Register<IBase>(c => new Disposable()).OwnedBy(Owner.External);

            var containerOwned = container.Resolve<IFoo>() as Disposable;
            var externallyOwned = container.Resolve<IBase>() as Disposable;

            container.Dispose();

            Assert.True(containerOwned.IsDisposed);
            Assert.False(externallyOwned.IsDisposed);
        }

        [Fact]
        public void ChildContainerCanReuseRegistrationsOnParent()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo());

            var child = container.CreateChildContainer();

            var foo = child.Resolve<IFoo>();

            Assert.NotNull(foo);
        }

        [Fact]
        public void NoReuseCreatesNewInstancesAlways()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.None);

            var foo1 = container.Resolve<IFoo>();
            var foo2 = container.Resolve<IFoo>();

            Assert.NotNull(foo1);
            Assert.NotNull(foo2);
            Assert.NotSame(foo1, foo2);
        }

        [Fact]
        public void ContainerScopedInstanceIsReused()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Container);


            var foo1 = container.Resolve<IFoo>();
            var foo2 = container.Resolve<IFoo>();

            Assert.NotNull(foo1);
            Assert.NotNull(foo2);
            Assert.Same(foo1, foo2);
        }

        [Fact]
        public void HierarchyScopedInstanceIsReusedOnSameContainer()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Hierarchy);

            var foo1 = container.Resolve<IFoo>();
            var foo2 = container.Resolve<IFoo>();

            Assert.NotNull(foo1);
            Assert.NotNull(foo2);
            Assert.Same(foo1, foo2);
        }

        [Fact]
        public void HierarchyScopedInstanceIsReusedFromParentContainer()
        {
            var parent = new Container();
            parent.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Hierarchy);
            var child = parent.CreateChildContainer();

            var foo1 = parent.Resolve<IFoo>();
            var foo2 = child.Resolve<IFoo>();

            Assert.NotNull(foo1);
            Assert.NotNull(foo2);
            Assert.Same(foo1, foo2);
        }

        [Fact]
        public void HierarchyScopedInstanceIsCreatedOnRegistrationContainer()
        {
            var parent = new Container();
            parent.Register<IFoo>(c => new Disposable()).ReusedWithin(ReuseScope.Hierarchy);
            var child = parent.CreateChildContainer();

            var childFoo = child.Resolve<IFoo>() as Disposable;
            var parentFoo = parent.Resolve<IFoo>() as Disposable;

            Assert.NotNull(parentFoo);
            Assert.NotNull(childFoo);

            child.Dispose();

            Assert.False(parentFoo.IsDisposed);
        }

        [Fact]
        public void ContainerScopedInstanceIsNotReusedFromParentContainer()
        {
            var parent = new Container();
            parent.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Container);
            var child = parent.CreateChildContainer();

            var foo1 = parent.Resolve<IFoo>();
            var foo2 = child.Resolve<IFoo>();

            Assert.NotNull(foo1);
            Assert.NotNull(foo2);
            Assert.NotSame(foo1, foo2);
        }

        [Fact]
        public void DisposingParentContainerDisposesChildContainerAndInstances()
        {
            var parent = new Container();
            parent.Register<IFoo>(c => new Disposable()).ReusedWithin(ReuseScope.Hierarchy);
            parent.Register<IBase>(c => new Disposable()).ReusedWithin(ReuseScope.Container);
            var child = parent.CreateChildContainer();

            var parentFoo = parent.Resolve<IFoo>() as Disposable;
            var childFoo = child.Resolve<IBase>() as Disposable;

            parent.Dispose();

            Assert.True(parentFoo.IsDisposed);
            Assert.True(childFoo.IsDisposed);
        }

        [Fact]
        public void ContainerOwnedNonReuseInstacesAreDisposed()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Disposable())
                .ReusedWithin(ReuseScope.None)
                .OwnedBy(Owner.Container);

            var foo = container.Resolve<IFoo>() as Disposable;

            container.Dispose();

            Assert.True(foo.IsDisposed);
        }

#if !DEBUG
        [Fact]
        public void ContainerOwnedNonReuseInstacesAreNotKeptAlive()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo())
                .ReusedWithin(ReuseScope.None)
                .OwnedBy(Owner.Container);

            var wr = new WeakReference(container.Resolve<IFoo>());
            var watch = Stopwatch.StartNew();

            // In DEBUG mode, this is unreliable as GC may or may not happen.
            while (wr.IsAlive)
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
                GC.WaitForFullGCApproach(-1);

                Assert.True(watch.ElapsedMilliseconds < 1000, "Instance was kept alive for too long");
            }

            Assert.False(wr.IsAlive);
        }
#endif

        [Fact]
        public void ContainerOwnedAndContainerReusedInstacesAreDisposed()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Disposable())
                .ReusedWithin(ReuseScope.Container)
                .OwnedBy(Owner.Container);

            var foo = container.Resolve<IFoo>() as Disposable;

            container.Dispose();

            Assert.True(foo.IsDisposed);
        }

        [Fact]
        public void ContainerOwnedAndHierarchyReusedInstacesAreDisposed()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Disposable())
                .ReusedWithin(ReuseScope.Hierarchy)
                .OwnedBy(Owner.Container);

            var foo = container.Resolve<IFoo>() as Disposable;

            container.Dispose();

            Assert.True(foo.IsDisposed);
        }

        [Fact]
        public void ChildContainerInstanceWithParentRegistrationIsDisposed()
        {
            var parent = new Container();
            parent.Register<IFoo>(c => new Disposable())
                .ReusedWithin(ReuseScope.Hierarchy)
                .OwnedBy(Owner.Container);

            var child = parent.CreateChildContainer();

            var foo = child.Resolve<IFoo>() as Disposable;

            child.Dispose();

            Assert.False(foo.IsDisposed);
        }

        [Fact]
        public void DisposingParentContainerDisposesChildContainerInstances()
        {
            var parent = new Container();
            parent.Register<IFoo>(c => new Disposable())
                .ReusedWithin(ReuseScope.None)
                .OwnedBy(Owner.Container);

            var child = parent.CreateChildContainer();

            var foo = child.Resolve<IFoo>() as Disposable;

            parent.Dispose();

            Assert.True(foo.IsDisposed);
        }

        [Fact]
        public void DisposingContainerDoesNotDisposeExternalOwnedInstances()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Disposable())
                .ReusedWithin(ReuseScope.Hierarchy)
                .OwnedBy(Owner.External);

            var foo = container.Resolve<IFoo>() as Disposable;

            container.Dispose();

            Assert.False(foo.IsDisposed);
        }

        [Fact]
        public void InitializerCalledWhenInstanceCreatedContainerReuse()
        {
            var container = new Container();
            container
                .Register<IInitializable>(c => new Initializable())
                .InitializedBy((c, i) => i.Initialize())
                .ReusedWithin(ReuseScope.Container);

            var i1 = container.Resolve<IInitializable>() as Initializable;
            var i2 = container.Resolve<IInitializable>() as Initializable;

            Assert.Same(i1, i2);
            Assert.Equal(1, i1.InitializeCalls);
        }

        [Fact]
        public void InitializerCalledWhenInstanceCreatedHierarchyReuse()
        {
            var container = new Container();
            container
                .Register<IInitializable>(c => new Initializable())
                .InitializedBy((c, i) => i.Initialize())
                .ReusedWithin(ReuseScope.Hierarchy);

            var i1 = container.Resolve<IInitializable>() as Initializable;
            var i2 = container.Resolve<IInitializable>() as Initializable;

            Assert.Same(i1, i2);
            Assert.Equal(1, i1.InitializeCalls);
        }

        [Fact]
        public void InitializerCalledWhenInstanceCreatedNoReuse()
        {
            var container = new Container();
            container
                .Register<IInitializable>(c => new Initializable())
                .InitializedBy((c, i) => i.Initialize())
                .ReusedWithin(ReuseScope.None);

            var i1 = container.Resolve<IInitializable>() as Initializable;
            var i2 = container.Resolve<IInitializable>() as Initializable;

            Assert.NotSame(i1, i2);
            Assert.Equal(1, i1.InitializeCalls);
            Assert.Equal(1, i2.InitializeCalls);
        }

        [Fact]
        public void InitializerCalledOnChildContainerWhenInstanceCreated()
        {
            var container = new Container();
            container
                .Register<IInitializable>(c => new Initializable())
                .InitializedBy((c, i) => i.Initialize())
                .ReusedWithin(ReuseScope.Container);

            var child = container.CreateChildContainer();

            var i1 = child.Resolve<IInitializable>() as Initializable;
            var i2 = child.Resolve<IInitializable>() as Initializable;

            Assert.Same(i1, i2);
            Assert.Equal(1, i1.InitializeCalls);
        }

        [Fact]
        public void InitializerCanRetrieveResolvedDependency()
        {
            var container = new Container();
            container.Register(c => new Presenter(c.Resolve<View>()));
            container.Register(c => new View())
                .InitializedBy((c, v) => v.Presenter = c.Resolve<Presenter>());

            var view = container.Resolve<View>();
            var presenter = container.Resolve<Presenter>();

            Assert.Same(view.Presenter, presenter);
        }

        [Fact]
        public void InitializerCalledOnEntryContainer()
        {
            var container = new Container();
            // Notice the purposedful error: we register the view 
            // on the parent container, but the presenter in 
            // the child. Since the reuse is hierarchy, the view 
            // will be created on the parent, and thus the 
            // initializer should NOT be able to resolve 
            // the presenter, which lives in the child container.
            container.Register(c => new View())
                .InitializedBy((c, v) => v.Presenter = c.Resolve<Presenter>())
                .ReusedWithin(ReuseScope.Hierarchy);

            var child = container.CreateChildContainer();
            child.Register(c => new Presenter(c.Resolve<View>()));

            try
            {
                var view = child.Resolve<View>();
                Assert.Fail("Should have thrown as presenter is registered on child and initializer runs on parent");
            }
            catch (ResolutionException)
            {
            }
        }

        [Fact]
        public void ThrowsIfRegisterContainerService()
        {
            try
            {
                var container = new Container();
                container.Register<Container>(c => new Container());
                Assert.Fail("Should have thrown when registering a Container service.");
            }
            catch (ArgumentException ex)
            {
                Assert.Equal(Properties.Resources.Registration_CantRegisterContainer, ex.Message);
            }
        }

        [Fact]
        public void ShouldGetContainerServiceAlways()
        {
            var container = new Container();

            var service = container.Resolve<Container>();

            Assert.NotNull(service);
        }

        [Fact]
        public void ShouldGetSameContainerServiceAsCurrentContainer()
        {
            var container = new Container();

            var service = container.Resolve<Container>();

            Assert.Same(container, service);

            var child = container.CreateChildContainer();

            service = child.Resolve<Container>();

            Assert.Same(child, service);

            var grandChild = child.CreateChildContainer();

            service = grandChild.Resolve<Container>();

            Assert.Same(grandChild, service);
        }

        [Fact]
        public void DefaultReuseCanBeSpecified()
        {
            var container = new Container { DefaultReuse = ReuseScope.None };

            container.Register<IFoo>(c => new Foo());

            var f1 = container.Resolve<IFoo>();
            var f2 = container.Resolve<IFoo>();

            Assert.NotSame(f1, f2);
        }

        [Fact]
        public void DefaultOwnerCanBeSpecified()
        {
            var container = new Container { DefaultOwner = Owner.External };

            container.Register(c => new Disposable());

            var d = container.Resolve<Disposable>();

            container.Dispose();

            Assert.False(d.IsDisposed);
        }

        [Fact]
        public void LazyResolveProvidedForRegisteredServices()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Container);

            var func = container.LazyResolve<IFoo>();

            Assert.NotNull(func);
        }

        [Fact]
        public void LazyResolveHonorsReuseScope()
        {
            var container = new Container();
            container.Register<IFoo>(c => new Foo()).ReusedWithin(ReuseScope.Container);

            var func = container.LazyResolve<IFoo>();

            var f1 = func();
            var f2 = func();

            Assert.Same(f1, f2);
        }

        [Fact]
        public void LazyResolveNamed()
        {
            var container = new Container();
            container.Register("foo", c => new Foo("foo"));
            container.Register("bar", c => new Foo("bar"));

            var foo = container.LazyResolveNamed<Foo>("foo");
            var bar = container.LazyResolveNamed<Foo>("bar");

            Assert.NotNull(foo);
            Assert.NotNull(bar);

            Assert.Equal("foo", foo().Value);
            Assert.Equal("bar", bar().Value);
        }

        [Fact]
        public void LazyResolveAllOverloads()
        {
            var container = new Container();

            container.Register<Bar>(c => new Bar());
            container.Register<Bar, string>((c, s) => new Bar(s));
            container.Register<Bar, string, string>((c, s1, s2) => new Bar(s1, s2));
            container.Register<Bar, string, string, string>((c, s1, s2, s3) => new Bar(s1, s2, s3));
            container.Register<Bar, string, string, string, string>((c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4));
            container.Register<Bar, string, string, string, string, string>((c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5));
            container.Register<Bar, string, string, string, string, string, string>((c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6));

            Assert.NotNull(container.Resolve<Bar>());

            var b = container.LazyResolve<Bar, string>()("a1");
            Assert.Equal("a1", b.Arg1);

            b = container.LazyResolve<Bar, string, string>()("a1", "a2");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);

            b = container.LazyResolve<Bar, string, string, string>()("a1", "a2", "a3");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);

            b = container.LazyResolve<Bar, string, string, string, string>()("a1", "a2", "a3", "a4");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);

            b = container.LazyResolve<Bar, string, string, string, string, string>()("a1", "a2", "a3", "a4", "a5");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);
            Assert.Equal("a5", b.Arg5);

            b = container.LazyResolve<Bar, string, string, string, string, string, string>()("a1", "a2", "a3", "a4", "a5", "a6");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);
            Assert.Equal("a5", b.Arg5);
            Assert.Equal("a6", b.Arg6);

        }

        [Fact]
        public void LazyResolveNamedAllOverloads()
        {
            var container = new Container();

            container.Register<Bar>("bar", c => new Bar());
            container.Register<Bar, string>("bar", (c, s) => new Bar(s));
            container.Register<Bar, string, string>("bar", (c, s1, s2) => new Bar(s1, s2));
            container.Register<Bar, string, string, string>("bar", (c, s1, s2, s3) => new Bar(s1, s2, s3));
            container.Register<Bar, string, string, string, string>("bar", (c, s1, s2, s3, s4) => new Bar(s1, s2, s3, s4));
            container.Register<Bar, string, string, string, string, string>("bar", (c, s1, s2, s3, s4, s5) => new Bar(s1, s2, s3, s4, s5));
            container.Register<Bar, string, string, string, string, string, string>("bar", (c, s1, s2, s3, s4, s5, s6) => new Bar(s1, s2, s3, s4, s5, s6));

            var b = container.ResolveNamed<Bar, string>("bar", "a1");
            Assert.Equal("a1", b.Arg1);

            b = container.ResolveNamed<Bar, string, string>("bar", "a1", "a2");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);

            b = container.ResolveNamed<Bar, string, string, string>("bar", "a1", "a2", "a3");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);

            b = container.ResolveNamed<Bar, string, string, string, string>("bar", "a1", "a2", "a3", "a4");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);

            b = container.ResolveNamed<Bar, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);
            Assert.Equal("a5", b.Arg5);

            b = container.ResolveNamed<Bar, string, string, string, string, string, string>("bar", "a1", "a2", "a3", "a4", "a5", "a6");
            Assert.Equal("a1", b.Arg1);
            Assert.Equal("a2", b.Arg2);
            Assert.Equal("a3", b.Arg3);
            Assert.Equal("a4", b.Arg4);
            Assert.Equal("a5", b.Arg5);
            Assert.Equal("a6", b.Arg6);
        }

        [Fact]
        public void LazyResolveThrowsIfNotRegistered()
        {
            var container = new Container();

            try
            {
                container.LazyResolve<IFoo>();
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolve<IFoo, string>();
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolve<IFoo, string, string>();
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolve<IFoo, string, string, string>();
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolve<IFoo, string, string, string, string>();
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolve<IFoo, string, string, string, string, string>();
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolve<IFoo, string, string, string, string, string, string>();
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

        }

        [Fact]
        public void LazyResolveNamedThrowsIfNotRegistered()
        {
            var container = new Container();

            try
            {
                container.LazyResolveNamed<IFoo>("foo");
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolveNamed<IFoo, string>("foo");
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolveNamed<IFoo, string, string>("foo");
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolveNamed<IFoo, string, string, string>("foo");
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolveNamed<IFoo, string, string, string, string>("foo");
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolveNamed<IFoo, string, string, string, string, string>("foo");
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }

            try
            {
                container.LazyResolveNamed<IFoo, string, string, string, string, string, string>("foo");
                Assert.Fail("Should have failed to resolve the lazy func");
            }
            catch (ResolutionException)
            {
            }
        }

        public class Presenter
        {
            public Presenter(View view)
            {
                this.View = view;
            }

            public View View { get; set; }
        }

        public class View
        {
            public Presenter Presenter { get; set; }
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
