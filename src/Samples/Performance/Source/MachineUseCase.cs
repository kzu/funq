using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Funq;
using Machine.Container;
using Domain;
using System.ComponentModel;

namespace Performance
{
	[Description("Machine")]
	public class MachineUseCase : UseCase
	{
		MachineContainer container;

		public MachineUseCase()
		{
			container = new MachineContainer();
			container.Initialize();
			container.PrepareForServices();

			container.Register.Type<IWebService>().ImplementedBy<WebService>().AsTransient();

			container.Register.Type<IAuthenticator>().ImplementedBy<Authenticator>().AsTransient();

			container.Register.Type<IStockQuote>().ImplementedBy<StockQuote>().AsTransient();

			container.Register.Type<IDatabase>().ImplementedBy<Database>().AsTransient();

			container.Register.Type<IErrorHandler>().ImplementedBy<ErrorHandler>().AsTransient();

			container.Add<ILogger>(new Logger());

			container.ReadyForServices();
		}

		public override void Run()
		{
			var webApp = container.Resolve.Object<IWebService>();
			webApp.Execute();
		}
	}
}
