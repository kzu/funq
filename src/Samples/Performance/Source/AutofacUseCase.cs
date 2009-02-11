using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Builder;

namespace Performance
{
	public class AutofacUseCase : UseCase
	{
		IContainer container;

		public AutofacUseCase()
		{
			var builder = new ContainerBuilder();
			builder.Register<IWebApp>(
				c => new WebApp(
					c.Resolve<IAuthenticator>(),
					c.Resolve<IStockQuote>()))
				.FactoryScoped();

			builder.Register<IAuthenticator>(
				c => new Authenticator(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()))
				.FactoryScoped();

			builder.Register<IStockQuote>(
				c => new StockQuote(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()))
				.FactoryScoped();

			builder.Register<IDatabase>(
				c => new Database(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>()))
				.FactoryScoped();

			builder.Register<IErrorHandler>(
				c => new ErrorHandler(c.Resolve<ILogger>()))
				.FactoryScoped();

			builder.Register<ILogger>(c => new Logger())
				.FactoryScoped();

			container = builder.Build();
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebApp>();
			webApp.Run();
		}
	}
}
