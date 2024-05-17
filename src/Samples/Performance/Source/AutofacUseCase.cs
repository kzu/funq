using Autofac;
using Domain;

namespace Performance
{
	public class AutofacUseCase : UseCase
	{
		IContainer container;

		public AutofacUseCase()
		{
			var builder = new ContainerBuilder();
			builder.Register<IWebService>(
				c => new WebService(
					c.Resolve<IAuthenticator>(),
					c.Resolve<IStockQuote>()));

			builder.Register<IAuthenticator>(
				c => new Authenticator(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()));

			builder.Register<IStockQuote>(
				c => new StockQuote(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()));

			builder.Register<IDatabase>(
				c => new Database(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>()));

			builder.Register<IErrorHandler>(
				c => new ErrorHandler(c.Resolve<ILogger>()));

			builder.RegisterInstance<ILogger>(new Logger());

			container = builder.Build();
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebService>();
			webApp.Execute();
		}
	}
}
