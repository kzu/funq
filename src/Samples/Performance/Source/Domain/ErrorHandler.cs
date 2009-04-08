using System;

namespace Domain
{
	public class ErrorHandler : IErrorHandler
	{
		ILogger logger;

		public ErrorHandler(ILogger logger)
		{
			this.logger = logger;
		}

		public ILogger Logger { get { return logger; } }

		#region Behavior

		#endregion
	}
}
