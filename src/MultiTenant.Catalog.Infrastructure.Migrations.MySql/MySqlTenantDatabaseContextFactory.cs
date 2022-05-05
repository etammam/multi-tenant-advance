using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.MySql;

public class MySqlTenantDatabaseContextFactory
    : IDesignTimeDbContextFactory<MySqlCatalogContext>
{
    public MySqlCatalogContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<CatalogContext>();
        builder.UseMySql(
            serverVersion: ServerVersion.AutoDetect(
                "Server=192.168.1.60;Port=3306;Database=tenant-catalog;Uid=root;Pwd=secret;"),
            connectionString: "Server=192.168.1.60;Port=3306;Database=tenant-catalog;Uid=root;Pwd=secret;",
            mySqlOptionsAction: config =>
                config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.MySql"));
        return new MySqlCatalogContext(builder.Options);
    }
}