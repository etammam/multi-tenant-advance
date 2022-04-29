using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.Sqlite
{
    public class SqliteTenantDatabaseContextFactory
        : IDesignTimeDbContextFactory<SqliteCatalogContext>
    {
        public SqliteCatalogContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CatalogContext>();
            builder.UseSqlite("DataSource=CatalogContext.db", config =>
                    config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.Sqlite"));
            return new SqliteCatalogContext(builder.Options);
        }
    }
}
