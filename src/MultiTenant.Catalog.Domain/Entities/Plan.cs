using Ardalis.GuardClauses;
using MultiTenant.Catalog.Domain.Common;

namespace MultiTenant.Catalog.Domain.Entities;

public class Plan : BaseEntity, IAggregateRoot
{
    public Plan(Guid id, string name, string description, decimal price, int maxUserCount, int maxDatabaseSize,
        int maxStorageSize, bool isDemoPlan = false, int expiry = 30)
    {
        Id = id;
        SetName(name);
        SetDescription(description);
        SetPrice(price);
        SetMaxUserCount(maxUserCount);
        SetMaxDatabaseSize(maxDatabaseSize);
        SetMaxStorageSize(maxStorageSize);
        SetIsDemoPlan(isDemoPlan);
        SetExpiry(expiry);
    }

    public Plan(string name, string description, decimal price, int maxUserCount, int maxDatabaseSize,
        int maxStorageSize, bool isDemoPlan = false, int expiry = 30) : this(Guid.NewGuid(),
        name,
        description,
        price,
        maxUserCount,
        maxDatabaseSize,
        maxStorageSize, isDemoPlan, expiry)
    {
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int MaxUserCount { get; private set; }
    public int MaxDatabaseSize { get; private set; }
    public int MaxStorageSize { get; private set; }
    public bool IsDemoPlan { get; private set; }
    public int Expiry { get; private set; }

    public ICollection<Subscription> Subscriptions { get; set; }

    public Plan SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name), "Plan name is required");
        return this;
    }

    public Plan SetDescription(string description)
    {
        Description = description;
        return this;
    }

    public Plan SetPrice(decimal price)
    {
        Price = price;
        return this;
    }

    public Plan SetMaxUserCount(int maxUserCount = 1)
    {
        MaxUserCount = maxUserCount;
        return this;
    }

    public Plan SetMaxDatabaseSize(int maxDatabaseSize = 1024)
    {
        MaxDatabaseSize = maxDatabaseSize;
        return this;
    }

    public Plan SetMaxStorageSize(int maxStorageSize = 5120)
    {
        MaxStorageSize = maxStorageSize;
        return this;
    }

    public Plan SetIsDemoPlan(bool isDemoPlan = false)
    {
        IsDemoPlan = isDemoPlan;
        return this;
    }

    public Plan SetExpiry(int expiry)
    {
        Expiry = Guard.Against.Negative(expiry, nameof(expiry),
            "Expiry should be greater than or equal 0");
        return this;
    }
}