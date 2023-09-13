using Ninject;
using Ninject.Modules;
using Domain;
using System.ComponentModel;

namespace Performance
{
    [Description("Ninject")]
	public class NinjectUseCase : UseCase
	{
		IKernel kernel;

		public NinjectUseCase() => kernel = new StandardKernel(new SampleModule());

		public override void Run()
		{
			var webApp = kernel.Get<IWebService>();
			webApp.Execute();
		}

		class SampleModule : NinjectModule
        {
			public override void Load()
			{
				Bind<IWebService>().ToMethod(
					c => new WebService(
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
					.InSingletonScope();

				Bind<ILogger>().ToConstant(new Logger());
			}
		}
	}
}
