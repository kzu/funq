namespace Domain
{
    public interface IWebApp
	{
		IAuthenticator Authenticator { get; }
		IStockQuote StockQuote { get; }
		void Run();
	}
}