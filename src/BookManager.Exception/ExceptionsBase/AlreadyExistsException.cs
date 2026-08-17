using System.Net;

namespace BookManager.Exception.ExceptionsBase;

public class AlreadyExistsException : BookManagerException
{
    public AlreadyExistsException(string message) : base(message)
    {
    }

    public override int StatusCode => (int)HttpStatusCode.Conflict;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}