using Microsoft.AspNetCore.Identity;

namespace MultiTenant.Catalog.Domain.Entities.Users;

public sealed class Role : IdentityRole<Guid>
{
    public Role(Guid id, string name, string section)
    {
        Id = id;
        Name = name;
        NormalizedName = name.ToUpper();
        Section = section;
    }

    public string Section { get; set; }
}