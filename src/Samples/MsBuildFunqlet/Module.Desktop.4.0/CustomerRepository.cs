using System;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace Module
{
	[Export(typeof(IRepository<Customer>))]
	internal class CustomerRepository : IRepository<Customer>
	{
		private TraceSource tracer;

		[ImportingConstructor]
		public CustomerRepository(TraceSource tracer)
		{
			this.tracer = tracer;
		}

		public bool Delete(int id)
		{
			return true;
		}

		public Customer Read(int id)
		{
			throw new NotImplementedException();
		}

		public bool Save(Customer value)
		{
			return true;
		}
	}
}
