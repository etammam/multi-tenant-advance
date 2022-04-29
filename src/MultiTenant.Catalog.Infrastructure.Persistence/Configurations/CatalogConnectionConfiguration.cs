using MultiTenant.Catalog.Domain.Enums;

namespace MultiTenant.Catalog.Infrastructure.Persistence.Configurations
{
    public class CatalogConnectionConfiguration
    {
        public string ConnectionString { get; set; } = default!;
        public DatabaseProvider Provider { get; set; }
    }
}
