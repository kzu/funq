using System.ComponentModel.Composition;
using System.Web.Mvc;

namespace Module
{
	[Export("Main", typeof(Controller))]
	public class MainController : Controller
	{
		private IRepository<Customer> repository;

		[ImportingConstructor]
		public MainController(IRepository<Customer> customerRepository)
		{
			this.repository = customerRepository;
		}
	}
}
