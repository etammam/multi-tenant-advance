using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.MySql;

public class MySqlCatalogContext : CatalogContext
{
    public MySqlCatalogContext(DbContextOptions<CatalogContext> options)
        : base(options)
    {
    }
}