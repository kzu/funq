using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funq.Tests
{
	[TestClass]
	public class ServiceKeyFixture
	{
		[TestMethod]
		public void KeyNotEqualsNull()
		{
			var key1 = new ServiceKey(typeof(Func<IDisposable>), null);

			Assert.AreNotEqual(key1, null);
			Assert.IsFalse(key1.Equals(null));
		}

		[TestMethod]
		public void KeyNotEqualsOtherType()
		{
			var key1 = new ServiceKey(typeof(Func<IDisposable>), null);

			Assert.AreNotEqual(key1, new object());
			Assert.IsFalse(key1.Equals(new object()));
		}

		[TestMethod]
		public void KeyEqualsSameReference()
		{
			var key1 = new ServiceKey(typeof(Func<IDisposable>), null);
			var key2 = key1;

			Assert.AreSame(key1, key2);
			Assert.IsTrue(ServiceKey.Equals(key1, key2));
			Assert.IsTrue(key1.Equals(key2));
		}

		[TestMethod]
		public void KeysAreEqualByType()
		{
			var key1 = new ServiceKey(typeof(Func<IDisposable>), null);
			var key2 = new ServiceKey(typeof(Func<IDisposable>), null);

			Assert.AreEqual(key1, key2);
			Assert.AreEqual(key1.GetHashCode(), key2.GetHashCode());
			Assert.IsTrue(ServiceKey.Equals(key1, key2));
			Assert.IsTrue(key1.Equals(key2));
		}

		[TestMethod]
		public void KeysAreEqualByTypeAndName()
		{
			var key1 = new ServiceKey(typeof(Func<IDisposable>), "foo");
			var key2 = new ServiceKey(typeof(Func<IDisposable>), "foo");

			Assert.AreEqual(key1, key2);
			Assert.AreEqual(key1.GetHashCode(), key2.GetHashCode());
			Assert.IsTrue(ServiceKey.Equals(key1, key2));
			Assert.IsTrue(key1.Equals(key2));
		}

		[TestMethod]
		public void KeysNotEqualByName()
		{
			var key1 = new ServiceKey(typeof(Func<IDisposable>), "foo");
			var key2 = new ServiceKey(typeof(Func<IDisposable>), "bar");

			Assert.AreNotEqual(key1, key2);
			Assert.AreNotEqual(key1.GetHashCode(), key2.GetHashCode());
			Assert.IsFalse(ServiceKey.Equals(key1, key2));
		}
	}
}
