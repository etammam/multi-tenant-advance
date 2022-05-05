using MultiTenant.Catalog.Domain.Common;

namespace MultiTenant.Catalog.Infrastructure.Common.Repositories;

public interface IRepository<TEntity>
    : IRepository<TEntity, Guid>
    where TEntity : IAggregateRoot, IBaseEntity
{
}