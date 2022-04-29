using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.Sqlite;

public class SqliteCatalogContext : CatalogContext
{
    public SqliteCatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }
}