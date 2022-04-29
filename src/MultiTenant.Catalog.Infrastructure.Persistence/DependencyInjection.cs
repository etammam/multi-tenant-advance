using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Catalog.Domain.Enums;
using MultiTenant.Catalog.Infrastructure.Persistence.Configurations;

namespace MultiTenant.Catalog.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogContext(this IServiceCollection services, Action<CatalogConnectionConfiguration> configurations)
    {
        var connectionConfiguration = new CatalogConnectionConfiguration();
        configurations.Invoke(connectionConfiguration);
        switch (connectionConfiguration.Provider)
        {
            case DatabaseProvider.SqlServer:
                services.AddDbContext<ICatalogContext, CatalogContext>(options =>
                {
                    options.UseSqlServer(connectionConfiguration.ConnectionString,
                        config => config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.SqlServer"));
                });
                break;
            case DatabaseProvider.MySql:
                services.AddDbContext<ICatalogContext, CatalogContext>(options =>
                {
                    options.UseMySql(serverVersion: ServerVersion.AutoDetect(connectionConfiguration.ConnectionString),
                        connectionString: connectionConfiguration.ConnectionString, mySqlOptionsAction: config =>
                            config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.MySql"));
                });
                break;
            case DatabaseProvider.PostgreSql:
                services.AddDbContext<ICatalogContext, CatalogContext>(options =>
                {
                    options.UseNpgsql(connectionConfiguration.ConnectionString,
                        config => config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.Npgsql"));
                });
                break;
            case DatabaseProvider.Oracle:
                services.AddDbContext<ICatalogContext, CatalogContext>(options =>
                {
                    options.UseOracle(connectionConfiguration.ConnectionString,
                        config => config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.Oracle"));
                });
                break;
            case DatabaseProvider.Sqlite:
                services.AddDbContext<ICatalogContext, CatalogContext>(options =>
                {
                    options.UseSqlite(connectionConfiguration.ConnectionString,
                        config => config.MigrationsAssembly("MultiTenant.Catalog.Infrastructure.Migrations.Sqlite"));
                });
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(connectionConfiguration.Provider.ToString),
                    "Database provider not supported");
        }
        return services;
    }
}