using MultiTenant.Catalog.Domain.Common;

namespace MultiTenant.Catalog.Domain.ValueObjects;

public class Contact : ValueObject
{
    public string Website { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public Contact() { }

    public Contact(string website, string email, string phone)
    {
        SetEmail(website);
        SetEmail(email);
        SetPhone(phone);
    }

    public Contact SetWebsite(string website)
    {
        Website = website;
        return this;
    }
    public Contact SetEmail(string email)
    {
        Email = email;
        return this;
    }
    public Contact SetPhone(string phone)
    {
        Phone = phone;
        return this;
    }
}