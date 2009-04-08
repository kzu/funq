using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.StaticFactory;
using Domain;

namespace Performance
{
	public class UnityUseCase : UseCase
	{
		UnityContainer container;

		public UnityUseCase()
		{
			container = new UnityContainer();
			container.AddExtension(new FactoryDefaultLifetime());

			var builder = container
				.AddNewExtension<StaticFactoryExtension>()
				.Configure<IStaticFactoryConfiguration>();

			builder.RegisterFactory<IWebApp>(
				c => new WebApp(
					c.Resolve<IAuthenticator>(),
					c.Resolve<IStockQuote>()));

			builder.RegisterFactory<IAuthenticator>(
				c => new Authenticator(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()));

			builder.RegisterFactory<IStockQuote>(
				c => new StockQuote(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>(),
					c.Resolve<IDatabase>()));

			builder.RegisterFactory<IDatabase>(
				c => new Database(
					c.Resolve<ILogger>(),
					c.Resolve<IErrorHandler>()));

			builder.RegisterFactory<IErrorHandler>(
				c => new ErrorHandler(c.Resolve<ILogger>()));

			builder.RegisterFactory<ILogger>(c => new Logger());
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebApp>();
			webApp.Run();
		}

		class FactoryDefaultLifetime : Microsoft.Practices.Unity.UnityContainerExtension
		{
			protected override void Initialize()
			{
				Context.Policies.SetDefault<Microsoft.Practices.ObjectBuilder2.ILifetimePolicy>(
					new Microsoft.Practices.ObjectBuilder2.TransientLifetimePolicy());
			}
		}
	}
}
