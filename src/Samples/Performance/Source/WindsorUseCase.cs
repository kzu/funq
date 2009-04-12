using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Domain;
using Castle.Core;
using System.ComponentModel;

namespace Performance
{
	[Description("Windsor")]
	public class WindsorUseCase : UseCase
	{
		private readonly IWindsorContainer container;

		public WindsorUseCase()
		{
			container = new WindsorContainer();

			Register<IWebApp, WebApp>();
			Register<IAuthenticator, Authenticator>();
			Register<IStockQuote, StockQuote>();
			Register<IDatabase, Database>();
			Register<IErrorHandler, ErrorHandler>();

			container.AddComponentWithLifestyle<ILogger, Logger>(LifestyleType.Singleton);

			Register<ILogger, Logger>();
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebApp>();
			webApp.Run();
		}

		public void Register<T, R>()
		{
			container.AddComponentWithLifestyle(typeof(T).Name, typeof(T), typeof(R), LifestyleType.Transient);
		}
	}
}
