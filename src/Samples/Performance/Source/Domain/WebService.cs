using System;

namespace Domain
{
	public class WebService : IWebService
	{
		IAuthenticator authenticator;
		IStockQuote quotes;

		public WebService(IAuthenticator authenticator, IStockQuote quotes)
		{
			this.authenticator = authenticator;
			this.quotes = quotes;
		}

		public IAuthenticator Authenticator { get { return authenticator; } }
		public IStockQuote StockQuote { get { return quotes; } }

		#region Behavior

		public void Execute()
		{
		}

		#endregion
	}
}