namespace Domain
{
    public interface IDatabase
	{
		ILogger Logger { get; }
		IErrorHandler ErrorHandler { get; }
	}
}
