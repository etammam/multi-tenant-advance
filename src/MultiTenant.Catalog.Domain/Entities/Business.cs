using Ardalis.GuardClauses;
using MultiTenant.Catalog.Domain.Common;

namespace MultiTenant.Catalog.Domain.Entities;

public class Business : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Business() { }

    public ICollection<Organization> Organizations { get; set; }

    public Business(Guid id, string name, string description)
    {
        Id = id;
        SetName(name);
        SetDescription(description);
    }

    public Business(string name, string description)
        : this(Guid.NewGuid(), name, description)
    {
    }

    public Business SetName(string name)
    {
        Name = Guard.Against.NullOrWhiteSpace(name, nameof(name), "Business name is required");
        return this;
    }

    public Business SetDescription(string description)
    {
        Description = description;
        return this;
    }
}