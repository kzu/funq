using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Core;
using Domain;

namespace Performance
{
	public class NinjectUseCase : UseCase
	{
		IKernel kernel;

		public NinjectUseCase()
		{
			kernel = new Ninject.Core.StandardKernel(new SampleModule());
		}

		public override void Run()
		{
			var webApp = kernel.Get<IWebApp>();
			webApp.Run();
		}

		class SampleModule : StandardModule
		{
			public override void Load()
			{
				Bind<IWebApp>().ToMethod(
					c => new WebApp(
						c.Kernel.Get<IAuthenticator>(),
						c.Kernel.Get<IStockQuote>()))
					.Using<Ninject.Core.Behavior.TransientBehavior>();

				Bind<IAuthenticator>().ToMethod(
					c => new Authenticator(
						c.Kernel.Get<ILogger>(),
						c.Kernel.Get<IErrorHandler>(),
						c.Kernel.Get<IDatabase>()))
					.Using<Ninject.Core.Behavior.TransientBehavior>();

				Bind<IStockQuote>().ToMethod(
					c => new StockQuote(
						c.Kernel.Get<ILogger>(),
						c.Kernel.Get<IErrorHandler>(),
						c.Kernel.Get<IDatabase>()))
					.Using<Ninject.Core.Behavior.TransientBehavior>();

				Bind<IDatabase>().ToMethod(
					c => new Database(
						c.Kernel.Get<ILogger>(),
						c.Kernel.Get<IErrorHandler>()))
					.Using<Ninject.Core.Behavior.TransientBehavior>();

				Bind<IErrorHandler>().ToMethod(
					c => new ErrorHandler(c.Kernel.Get<ILogger>()))
					.Using<Ninject.Core.Behavior.TransientBehavior>();

				Bind<ILogger>().ToMethod(c => new Logger())
					.Using<Ninject.Core.Behavior.TransientBehavior>();
			}
		}
	}
}
