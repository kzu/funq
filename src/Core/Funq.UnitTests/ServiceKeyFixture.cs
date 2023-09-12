using System;

namespace Funq.Tests
{
    public class ServiceKeyFixture
    {
        [Fact]
        public void KeyNotEqualsNull()
        {
            var key1 = new ServiceKey(typeof(Func<IDisposable>), null);

            Assert.NotNull(key1);
            Assert.False(key1.Equals(null));
        }

        [Fact]
        public void KeyNotEqualsOtherType()
        {
            var key1 = new ServiceKey(typeof(Func<IDisposable>), null);

            Assert.NotEqual(key1, new object());
            Assert.False(key1.Equals(new object()));
        }

        [Fact]
        public void KeyEqualsSameReference()
        {
            var key1 = new ServiceKey(typeof(Func<IDisposable>), null);
            var key2 = key1;

            Assert.Same(key1, key2);
            Assert.True(ServiceKey.Equals(key1, key2));
            Assert.True(key1.Equals(key2));
        }

        [Fact]
        public void KeysAreEqualByType()
        {
            var key1 = new ServiceKey(typeof(Func<IDisposable>), null);
            var key2 = new ServiceKey(typeof(Func<IDisposable>), null);

            Assert.Equal(key1, key2);
            Assert.Equal(key1.GetHashCode(), key2.GetHashCode());
            Assert.True(ServiceKey.Equals(key1, key2));
            Assert.True(key1.Equals(key2));
        }

        [Fact]
        public void KeysAreEqualByTypeAndName()
        {
            var key1 = new ServiceKey(typeof(Func<IDisposable>), "foo");
            var key2 = new ServiceKey(typeof(Func<IDisposable>), "foo");

            Assert.Equal(key1, key2);
            Assert.Equal(key1.GetHashCode(), key2.GetHashCode());
            Assert.True(ServiceKey.Equals(key1, key2));
            Assert.True(key1.Equals(key2));
        }

        [Fact]
        public void KeysNotEqualByName()
        {
            var key1 = new ServiceKey(typeof(Func<IDisposable>), "foo");
            var key2 = new ServiceKey(typeof(Func<IDisposable>), "bar");

            Assert.NotEqual(key1, key2);
            Assert.NotEqual(key1.GetHashCode(), key2.GetHashCode());
            Assert.False(ServiceKey.Equals(key1, key2));
        }
    }
}
