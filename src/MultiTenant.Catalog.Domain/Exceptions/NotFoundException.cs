using System.Net;

namespace MultiTenant.Catalog.Domain.Exceptions;

public class NotFoundException : DomainException
{
    public NotFoundException(string key, string objectName)
        : base($"Queried object {objectName} was not found, Key: {key}")
    {
        Error.StatusCode = (int)HttpStatusCode.NotFound;
        ExceptionType = nameof(NotFoundException);
    }

    public NotFoundException(string key, string objectName, Exception innerException) :
        base($"Queried object {objectName} was not found, Key: {key}", innerException)
    {
        Error.StatusCode = (int)HttpStatusCode.NotFound;
        ExceptionType = nameof(NotFoundException);
        Error.InnerException = InnerException;
    }
}