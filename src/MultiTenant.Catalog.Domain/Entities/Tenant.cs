using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Domain.Enums;

namespace MultiTenant.Catalog.Domain.Entities;

public class Tenant : BaseEntity, IAggregateRoot
{
    protected Tenant()
    {
    }

    public Tenant(Guid id, string name, Guid resourceId, DatabaseProvider provider)
    {
        Id = id;
        SetName(name);
        SetResourceId(resourceId);
        SetDatabaseProvider(provider);
    }

    public Tenant(string name, Guid resourceId, DatabaseProvider provider)
    {
        SetName(name);
        SetResourceId(resourceId);
        SetDatabaseProvider(provider);
    }

    public string Identifier { get; private set; }
    public string Name { get; private set; }
    public Resource Resource { get; private set; }
    public Guid ResourceId { get; private set; }
    public string ConnectionString { get; private set; }
    public DatabaseProvider DatabaseProvider { get; private set; }
    public Organization Organization { get; set; }

    public Tenant SetIdentifier(string identifier)
    {
        Identifier = identifier;
        return this;
    }

    public Tenant SetName(string name)
    {
        Name = name;
        return this;
    }

    public Tenant SetResource(Resource resource)
    {
        Resource = resource;
        return this;
    }

    public Tenant SetResourceId(Guid resourceId)
    {
        ResourceId = resourceId;
        return this;
    }

    public Tenant SetConnectionString(string connectionString)
    {
        ConnectionString = connectionString;
        return this;
    }

    public Tenant SetDatabaseProvider(DatabaseProvider databaseProvider)
    {
        DatabaseProvider = databaseProvider;
        return this;
    }
}