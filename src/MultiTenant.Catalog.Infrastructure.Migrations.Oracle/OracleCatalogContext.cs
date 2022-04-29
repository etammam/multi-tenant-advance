using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.Oracle;

public class OracleCatalogContext : CatalogContext
{
    public OracleCatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }
}