using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.Oracle;

public class OracleTenantDatabaseContextFactory
    : IDesignTimeDbContextFactory<OracleCatalogContext>
{
    public OracleCatalogContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<CatalogContext>(); //tenant-catalog
        builder.UseOracle("", config =>
            config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.Oracle"));
        return new OracleCatalogContext(builder.Options);
    }
}