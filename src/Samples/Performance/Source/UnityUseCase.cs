using System;
using Domain;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using Unity;

namespace Performance
{
    [Description("Unity")]
	public class UnityUseCase : UseCase
	{
		UnityContainer container;

		public UnityUseCase()
		{
			container = new UnityContainer();

			container.RegisterFactory<IWebService>(
				c => new WebService(
					c.Resolve<IAuthenticator>(),
					c.Resolve<IStockQuote>()));

            container.RegisterFactory<IAuthenticator>(
				c => new Authenticator(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()));

            container.RegisterFactory<IStockQuote>(
				c => new StockQuote(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()));

            container.RegisterFactory<IDatabase>(
				c => new Database(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>()));

            container.RegisterFactory<IErrorHandler>(
				c => new ErrorHandler(c.Resolve<ILogger>()));

			var logger = new Logger();

			try
			{
				// Why on earth is this throwing?!?!?!
				container.RegisterInstance<ILogger>(logger);
			}
			catch (SynchronizationLockException) { }

			Debug.Assert(Object.ReferenceEquals(logger, container.Resolve<ILogger>()));
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebService>();
			webApp.Execute();
		}
	}
}
