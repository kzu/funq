using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Funq;
using Domain;
using System.Reflection;

namespace Performance
{
	public partial class DomainFunqlet : IConventionFunqlet
	{
		public Convention GetConvention()
		{
			return new Convention(ConventionKind.Services,
				from t in Assembly.GetExecutingAssembly().GetExportedTypes()
				where t.Namespace == "Domain" && t.IsClass && !t.IsAbstract
				select t)
			{
				Reuse = ReuseScope.None
			};
		}

		public void Configure(Container container)
		{
			DoConfigure(container);
		}

		partial void DoConfigure(Container container);
	}

	public class FunqUseCase : UseCase
	{
		Container container;

		public FunqUseCase()
		{
			container = new Container { DefaultReuse = ReuseScope.None };

			// Remove the need for all the following code 
			// by implementing a funqlet
			new DomainFunqlet().Configure(container);

			//container.Register<IWebApp>(
			//   c => new WebApp(
			//      c.Resolve<IAuthenticator>(),
			//      c.Resolve<IStockQuote>()));

			//container.Register<IAuthenticator>(
			//   c => new Authenticator(
			//      c.Resolve<ILogger>(),
			//      c.Resolve<IErrorHandler>(),
			//      c.Resolve<IDatabase>()));

			//container.Register<IStockQuote>(
			//   c => new StockQuote(
			//      c.Resolve<ILogger>(),
			//      c.Resolve<IErrorHandler>(),
			//      c.Resolve<IDatabase>()));

			//container.Register<IDatabase>(
			//   c => new Database(
			//      c.Resolve<ILogger>(),
			//      c.Resolve<IErrorHandler>()));

			//container.Register<IErrorHandler>(
			//   c => new ErrorHandler(c.Resolve<ILogger>()));

			//container.Register<ILogger>(c => new Logger());
		}

		public override void Run()
		{
			var webApp = container.Resolve<IWebApp>();
			webApp.Run();
		}
	}
}
