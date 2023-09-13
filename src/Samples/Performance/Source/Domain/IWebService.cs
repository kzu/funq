namespace Domain
{
    public interface IWebService
	{
		IAuthenticator Authenticator { get; }
		IStockQuote StockQuote { get; }
		void Execute();
	}
}