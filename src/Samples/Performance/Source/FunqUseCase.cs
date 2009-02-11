using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Funq;

namespace Performance
{
	public class FunqUseCase : UseCase
	{
		Container container;

		public FunqUseCase()
		{
			var builder = new ContainerBuilder { DefaultReuse = ReuseScope.None };
			builder.Register<IWebApp>(
				c => new WebApp(
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

			builder.Register<ILogger>(c => new Logger());

			container = builder.Build();
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebApp>();
			webApp.Run();
		}
	}
}
