namespace MultiTenant.Catalog.Domain.Exceptions;

public class SubscriptionStartDateException : DomainException
{
    public SubscriptionStartDateException(
        string message = "subscription start date should be equal or greater than today.")
        : base(message)
    {
    }
}