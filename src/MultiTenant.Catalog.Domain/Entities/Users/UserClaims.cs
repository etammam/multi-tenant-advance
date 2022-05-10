using Microsoft.AspNetCore.Identity;

namespace MultiTenant.Catalog.Domain.Entities.Users;

public class UserClaims : IdentityUserClaim<Guid>
{
}