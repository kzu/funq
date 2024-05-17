using Castle.Windsor;
using Domain;
using Castle.MicroKernel.Registration;

namespace Performance
{
	public class WindsorUseCase : UseCase
	{
		readonly IWindsorContainer container;

		public WindsorUseCase()
		{
			container = new WindsorContainer();

			Register<IWebService, WebService>();
			Register<IAuthenticator, Authenticator>();
			Register<IStockQuote, StockQuote>();
			Register<IDatabase, Database>();
			Register<IErrorHandler, ErrorHandler>();

            container.Register(Component.For<ILogger>().ImplementedBy<Logger>().LifestyleSingleton());
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebService>();
			webApp.Execute();
		}

		public void Register<T, R>() 
            where T : class
            where R : class, T
		{
            container.Register(Component.For<T>().ImplementedBy<R>().LifestyleTransient());
		}
	}
}
