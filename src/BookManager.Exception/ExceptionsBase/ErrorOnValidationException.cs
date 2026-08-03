using System.Net;

namespace BookManager.Exception.ExceptionsBase;

public class ErrorOnValidationException : BookManagerException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
    {
        _errors = errorMessages;
    }

    public override List<string> GetErrors()
    {
        return _errors;
    }
}