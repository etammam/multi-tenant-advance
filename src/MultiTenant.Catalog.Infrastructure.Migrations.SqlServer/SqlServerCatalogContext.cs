using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.SqlServer;

public class SqlServerCatalogContext : CatalogContext
{
    public SqlServerCatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }
}