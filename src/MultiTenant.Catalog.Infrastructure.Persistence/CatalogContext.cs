using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Infrastructure.Persistence.EntityConfigurations;

namespace MultiTenant.Catalog.Infrastructure.Persistence;

public class CatalogContext : DbContext, ICatalogContext
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