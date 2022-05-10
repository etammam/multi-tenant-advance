using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Domain.Entities.Users;
using MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations;

namespace MultiTenant.Catalog.Infrastructure.Persistence;

public class CatalogContext :
    IdentityDbContext<User, Role, Guid, UserClaims, UserRoles, UserLogins, RoleClaims, UserTokens>,
    ICatalogContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantEntityConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}