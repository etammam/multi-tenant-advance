using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Migrations.Npgsql;

public class NpgsqlCatalogContext : CatalogContext
{
    public NpgsqlCatalogContext(DbContextOptions<CatalogContext> options) : base(options)
    {
    }
}