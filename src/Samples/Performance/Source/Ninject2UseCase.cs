using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;
using Domain;

namespace Performance
{
	public class Ninject2UseCase : UseCase
	{
		IKernel kernel;

		public Ninject2UseCase()
		{
			kernel = new Ninject.StandardKernel(new SampleModule());
		}

		public override void Run()
		{
			var webApp = kernel.Get<IWebApp>();
			webApp.Run();
		}

		class SampleModule : Module
		{
			public override void Load()
			{
				Bind<IWebApp>().ToMethod(
					c => new WebApp(
						c.Kernel.Get<IAuthenticator>(),
						c.Kernel.Get<IStockQuote>()))
					.InTransientScope();

				Bind<IAuthenticator>().ToMethod(
					c => new Authenticator(
						c.Kernel.Get<ILogger>(),
						c.Kernel.Get<IErrorHandler>(),
						c.Kernel.Get<IDatabase>()))
					.InTransientScope();

				Bind<IStockQuote>().ToMethod(
					c => new StockQuote(
						c.Kernel.Get<ILogger>(),
						c.Kernel.Get<IErrorHandler>(),
						c.Kernel.Get<IDatabase>()))
					.InTransientScope();

				Bind<IDatabase>().ToMethod(
					c => new Database(
						c.Kernel.Get<ILogger>(),
						c.Kernel.Get<IErrorHandler>()))
					.InTransientScope();

				Bind<IErrorHandler>().ToMethod(
					c => new ErrorHandler(c.Kernel.Get<ILogger>()))
					.InTransientScope();

				Bind<ILogger>().ToMethod(c => new Logger())
					.InTransientScope();
			}
		}
	}
}
