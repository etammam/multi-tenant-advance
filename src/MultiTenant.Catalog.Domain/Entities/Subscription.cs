using Ardalis.GuardClauses;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Domain.Exceptions;

namespace MultiTenant.Catalog.Domain.Entities;

public class Subscription : BaseEntity
{
    public Subscription()
    {
    }

    public Subscription(Guid id, Guid planId, DateTime startDate, int expiry)
    {
        Id = id;
        SetPlanId(planId);
        SetExpiry(expiry);
        SetStartDate(startDate);
    }

    public Subscription(Guid planId, DateTime startDate, int expiry)
        : this(Guid.NewGuid(), planId, startDate, expiry)
    {
    }

    public Subscription(Guid id, DateTime startDate, int expiry, Guid organizationId)
    {
        Id = id;
        SetOrganizationId(organizationId);
        SetExpiry(expiry);
        SetStartDate(startDate);
    }

    public Subscription(DateTime startDate, int expiry, Guid organizationId)
        : this(Guid.NewGuid(), startDate, expiry, organizationId)
    {
    }

    public Guid PlanId { get; set; }
    public Plan Plan { get; set; }
    public DateTime StartDate { get; set; }
    public int Expiry { get; set; }
    public Guid OrganizationId { get; set; }
    public Organization Organization { get; set; }


    public Subscription SetPlanId(Guid planId)
    {
        PlanId = planId;
        return this;
    }

    public Subscription SetStartDate(DateTime startDate)
    {
        if (startDate < DateTime.Today)
            throw new SubscriptionStartDateException();
        StartDate = startDate;
        return this;
    }

    public Subscription SetExpiry(int expiry)
    {
        Expiry = Guard.Against.Negative(expiry, nameof(expiry),
            "Expiry should be greater than or equal 0");
        return this;
    }

    public Subscription SetOrganizationId(Guid organizationId)
    {
        OrganizationId = organizationId;
        return this;
    }
}