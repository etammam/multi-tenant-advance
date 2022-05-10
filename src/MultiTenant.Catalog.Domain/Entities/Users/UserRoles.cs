using Microsoft.AspNetCore.Identity;

namespace MultiTenant.Catalog.Domain.Entities.Users;

public sealed class UserRoles : IdentityUserRole<Guid>
{
    public UserRoles()
    { }

    public UserRoles(Guid userId, Guid roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}