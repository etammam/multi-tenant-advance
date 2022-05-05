using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Common.Repositories;

public class Repository<TEntity> : Repository<TEntity, Guid>, IRepository<TEntity>
    where TEntity : class, IAggregateRoot, IBaseEntity
{
    public Repository(ICatalogContext dbContext)
        : base(dbContext)
    {
    }
}