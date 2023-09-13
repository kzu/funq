namespace Domain
{
    public interface IAuthenticator
	{
		ILogger Logger { get; }
		IErrorHandler ErrorHandler { get; }
		IDatabase Database { get; }
	}
}