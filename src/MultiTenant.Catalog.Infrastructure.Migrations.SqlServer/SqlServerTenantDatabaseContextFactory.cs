using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.SqlServer;

public class SqlServerTenantDatabaseContextFactory
    : IDesignTimeDbContextFactory<SqlServerCatalogContext>
{
    public SqlServerCatalogContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<CatalogContext>();
        builder.UseSqlServer(
            "Data Source=.;Initial Catalog=Tenant-Catalog;User Id=Sa;Password=MadCode@01100072682;",
            config =>
                config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.SqlServer"));
        return new SqlServerCatalogContext(builder.Options);
    }
}