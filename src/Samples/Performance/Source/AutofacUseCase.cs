using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Builder;
using Domain;

namespace Performance
{
	[System.ComponentModel.Description("Autofac")]
	public class AutofacUseCase : UseCase
	{
		IContainer container;

		public AutofacUseCase()
		{
			var builder = new ContainerBuilder();
			builder.Register<IWebService>(
				c => new WebService(
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

			builder.Register<ILogger>(new Logger());

			container = builder.Build();
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebService>();
			webApp.Execute();
		}
	}
}
