using StructureMap;
using Domain;

namespace Performance
{
	public class StructureMapUseCase : UseCase
	{
		Container container;

		public StructureMapUseCase()
		{
			container = new Container();
			container.Configure(
				x => x.For<IWebService>().Transient().Use(
					c => new WebService(
						c.GetInstance<IAuthenticator>(),
						c.GetInstance<IStockQuote>())
					));

			container.Configure(
				x => x.For<IAuthenticator>().Transient().Use(
					c => new Authenticator(
						c.GetInstance<ILogger>(), 
						c.GetInstance<IErrorHandler>(), 
						c.GetInstance<IDatabase>())
					));

			container.Configure(
				x => x.For<IStockQuote>().Transient().Use(
					c => new StockQuote(
						c.GetInstance<ILogger>(),
						c.GetInstance<IErrorHandler>(),
						c.GetInstance<IDatabase>())
					));

			container.Configure(
				x => x.For<IDatabase>().Transient().Use(
					c => new Database(
						c.GetInstance<ILogger>(), 
						c.GetInstance<IErrorHandler>())
					));

			container.Configure(
				x => x.For<IErrorHandler>().Transient().Use(
					c => new ErrorHandler(c.GetInstance<ILogger>())
					));

			container.Configure(
				x => x.For<ILogger>().Use(new Logger()));
		}

		public override void Run()
		{
			var webApp = container.GetInstance<IWebService>();
			webApp.Execute();
		}
	}
}
