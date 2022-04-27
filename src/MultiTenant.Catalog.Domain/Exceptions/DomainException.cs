using Xeptions;

namespace MultiTenant.Catalog.Domain.Exceptions;

public class DomainException : Xeption
{
    public DomainException(string message)
    {

    }
    public DomainException(string message, Exception innerException)
    : base(message, innerException)
    {
    }
}