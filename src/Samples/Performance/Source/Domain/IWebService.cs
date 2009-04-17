using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
	public interface IWebService
	{
		IAuthenticator Authenticator { get; }
		IStockQuote StockQuote { get; }
		void Execute();
	}
}