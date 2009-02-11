using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Funq.Tests
{
	[TestClass]
	public class ContainerBuilderFixture
	{
		[TestMethod]
		public void RegistrationUsesDefaultOwner()
		{
			var builder = new ContainerBuilder { DefaultOwner = Owner.External };
			var registration = builder.Register(c => new object()) as Registration;

			Assert.AreEqual(Owner.External, registration.Owner);
		}

		[TestMethod]
		public void RegistrationUsesDefaultScope()
		{
			var builder = new ContainerBuilder { DefaultReuse = ReuseScope.None };
			var registration = builder.Register(c => new object()) as Registration;

			Assert.AreEqual(ReuseScope.None, registration.Scope);
		}
	}
}
