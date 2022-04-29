using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.Npgsql
{
    public class NpgsqlTenantDatabaseContextFactory
        : IDesignTimeDbContextFactory<NpgsqlCatalogContext>
    {
        public NpgsqlCatalogContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CatalogContext>();
            builder.UseNpgsql(
                "User Id=postgres;Password=MadCode@01100072682;Host=192.168.1.60;Database=tenant-catalog;",
                config =>
                    config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.Npgsql"));
            return new NpgsqlCatalogContext(builder.Options);
        }
    }
}
