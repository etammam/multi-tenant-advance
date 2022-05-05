namespace MultiTenant.Catalog.Domain.Exceptions;

public class InvalidUrlException : DomainException
{
    public InvalidUrlException(string argument)
        : base($"this {argument} has no valid url")
    {
    }
}