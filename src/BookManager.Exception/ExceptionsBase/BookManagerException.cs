namespace BookManager.Exception.ExceptionsBase;

public abstract class BookManagerException : SystemException
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();

    protected BookManagerException(string message) : base(message)
    {
    }
}
