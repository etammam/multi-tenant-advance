using MultiTenant.Catalog.Domain.Exceptions.Produce;
using Xeptions;

namespace MultiTenant.Catalog.Domain.Exceptions;

public class DomainException : Xeption
{
    public DomainException(string message)
    {
        Error.Message = message;
        Message = message;
    }

    public DomainException(string message, Exception innerException)
        : base(message, innerException)
    {
        Error.Message = message;
        Error.InnerException = innerException;
    }

    public ErrorModel Error { get; set; } = new();
    public string ExceptionType { get; set; }
    public override string Message { get; } = string.Empty;
}