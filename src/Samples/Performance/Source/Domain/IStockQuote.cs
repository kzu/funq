using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
	public interface IStockQuote
	{
		ILogger Logger { get; }
		IErrorHandler ErrorHandler { get; }
		IDatabase Database { get; }
	}
}