using System;
using Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Performance
{
    public class ServiceCollectionUseCase : UseCase
    {
        IServiceProvider services;

        public ServiceCollectionUseCase()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<IWebService>(
                s => new WebService(
                    s.GetRequiredService<IAuthenticator>(),
                    s.GetRequiredService<IStockQuote>()));

            collection.AddSingleton<IAuthenticator>(
                s => new Authenticator(
                    s.GetRequiredService<ILogger>(),
                    s.GetRequiredService<IErrorHandler>(),
                    s.GetRequiredService<IDatabase>()));

            collection.AddSingleton<IStockQuote>(
                s => new StockQuote(
                    s.GetRequiredService<ILogger>(),
                    s.GetRequiredService<IErrorHandler>(),
                    s.GetRequiredService<IDatabase>()));

            collection.AddSingleton<IDatabase>(
                s => new Database(
                    s.GetRequiredService<ILogger>(),
                    s.GetRequiredService<IErrorHandler>()));

            collection.AddSingleton<IErrorHandler>(
                s => new ErrorHandler(s.GetRequiredService<ILogger>()));

            collection.AddSingleton<ILogger>(new Logger());

            services = collection.BuildServiceProvider();
        }

        public override void Run()
        {
            var webApp = services.GetRequiredService<IWebService>();
            webApp.Execute();
        }
    }
}
