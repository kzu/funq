﻿using Funq;
using Domain;

namespace Performance
{
	public class FunqUseCase : UseCase
	{
		Container container;

		public FunqUseCase()
		{
			container = new Container { DefaultReuse = ReuseScope.None };

			container.Register<IWebService>(
				c => new WebService(
					c.Resolve<IAuthenticator>(),
					c.Resolve<IStockQuote>()));

			container.Register<IAuthenticator>(
				c => new Authenticator(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()));

			container.Register<IStockQuote>(
				c => new StockQuote(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()));

			container.Register<IDatabase>(
				c => new Database(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>()));

			container.Register<IErrorHandler>(
				c => new ErrorHandler(c.Resolve<ILogger>()));

			container.Register<ILogger>(new Logger());
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebService>();
			webApp.Execute();
		}
	}
}
