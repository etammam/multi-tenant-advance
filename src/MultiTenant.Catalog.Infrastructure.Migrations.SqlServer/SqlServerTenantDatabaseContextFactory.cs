using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.SqlServer
{
    public class SqlServerTenantDatabaseContextFactory
        : IDesignTimeDbContextFactory<SqlServerCatalogContext>
    {
        public SqlServerCatalogContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CatalogContext>();
            builder.UseSqlServer(
                "Data Source=192.168.1.60; User Id=sa; Password=Code@1903; Initial Catalog= Tenant-Catalog;",
                config =>
                    config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.SqlServer"));
            return new SqlServerCatalogContext(builder.Options);
        }
    }
}
