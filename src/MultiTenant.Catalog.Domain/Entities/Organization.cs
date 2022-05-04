using Ardalis.GuardClauses;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Domain.ValueObjects;

namespace MultiTenant.Catalog.Domain.Entities;

public class Organization : BaseEntity, IAggregateRoot
{
    public Organization()
    {
        Contact = new Contact();
        Address = new List<Address>();
    }

    public Organization(Guid id, string name, string vatNumber, Guid businessId)
    {
        Contact = new Contact();
        Address = new List<Address>();
    }

    public Organization(string name, string vatNumber, Guid businessId)
    : this(Guid.NewGuid(), name, vatNumber, businessId)
    {

    }

    public string Name { get; set; }
    public string Logo { get; set; }
    public Contact Contact { get; set; }
    public ICollection<Address> Address { get; set; }
    public string VatNumber { get; set; }
    public Guid BusinessId { get; set; }
    public Business Business { get; set; }

    public Tenant Tenant { get; set; }

    public ICollection<Subscription> Subscriptions { get; set; }

    public Organization SetName(string name)
    {
        Name = Guard.Against.NullOrEmpty(name, nameof(name), "Organization name is required");
        return this;
    }

    public Organization SetLogo(string logo)
    {
        Logo = logo;
        return this;
    }

    public Organization SetContact(Contact contact)
    {
        Contact = contact;
        return this;
    }

    public Organization SetAddress(Address address)
    {
        Address.Add(address);
        return this;
    }

    public Organization SetVatNumber(string vatNumber)
    {
        VatNumber = vatNumber;
        return this;
    }

    public Organization SetBusinessId(Guid businessId)
    {
        BusinessId = businessId;
        return this;
    }

}