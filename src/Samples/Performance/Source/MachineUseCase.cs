using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Funq;
using Machine.Container;
using Domain;

namespace Performance
{
	public class MachineUseCase : UseCase
	{
		MachineContainer container;

		public MachineUseCase()
		{
			container = new MachineContainer();
			container.Initialize();
			container.PrepareForServices();

			container.Register.Type<IWebApp>().ImplementedBy<WebApp>().AsTransient();

			container.Register.Type<IAuthenticator>().ImplementedBy<Authenticator>().AsTransient();

			container.Register.Type<IStockQuote>().ImplementedBy<StockQuote>().AsTransient();

			container.Register.Type<IDatabase>().ImplementedBy<Database>().AsTransient();

			container.Register.Type<IErrorHandler>().ImplementedBy<ErrorHandler>().AsTransient();

			container.Register.Type<ILogger>().ImplementedBy<Logger>().AsTransient();

			container.ReadyForServices();
		}

		public override void Run()
		{
			var webApp = container.Resolve.Object<IWebApp>();
			webApp.Run();
		}
	}
}
