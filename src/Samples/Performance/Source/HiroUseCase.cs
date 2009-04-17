using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hiro;
using Hiro.ActivationPoints;
using Hiro.Containers;
using Hiro.Interfaces;
using LinFu.Reflection.Emit;
using Domain;
using System.ComponentModel;

namespace Performance
{
	[Description("Hiro")]
	public class HiroUseCase : UseCase
	{
		IMicroContainer container;

		public HiroUseCase()
		{
			var map = new DependencyMap();
			map.AddService(typeof(IWebService), typeof(WebService));
			map.AddService(typeof(IAuthenticator), typeof(Authenticator));
			map.AddService(typeof(IStockQuote), typeof(StockQuote));
			map.AddService(typeof(IDatabase), typeof(Database));
			map.AddService(typeof(IErrorHandler), typeof(ErrorHandler));
			map.AddService(typeof(ILogger), typeof(Logger));

			IContainerCompiler compiler = new ContainerCompiler();
			var assembly = compiler.Compile(map);

			var loadedAssembly = assembly.ToAssembly();
			var containerType = loadedAssembly.GetTypes()[0];
			container = (IMicroContainer)Activator.CreateInstance(containerType);
		}

		public override void Run()
		{
			var webApp = (IWebService)container.GetInstance(typeof(IWebService), null);
			webApp.Execute();
		}
	}
}
