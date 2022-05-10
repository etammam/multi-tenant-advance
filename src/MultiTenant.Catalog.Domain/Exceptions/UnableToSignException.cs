using System.Net;

namespace MultiTenant.Catalog.Domain.Exceptions;

public class UnableToSignException : DomainException
{
    public UnableToSignException(string emailAddress, string message = null)
        : base($"User with {emailAddress}, unable to signin please check with your administrator")
    {
        ExceptionType = nameof(UnableToSignException);
        Error.StatusCode = (int)HttpStatusCode.Unauthorized;
    }

    public UnableToSignException(string emailAddress, Exception innerException, string message = null)
        : base($"User with {emailAddress}, unable to signin please check with your administrator", innerException)
    {
    }
}