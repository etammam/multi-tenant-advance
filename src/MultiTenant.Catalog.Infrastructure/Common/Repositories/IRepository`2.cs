using MultiTenant.Catalog.Core.Generic.Models;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Infrastructure.Common.Specifications;

namespace MultiTenant.Catalog.Infrastructure.Common.Repositories;

public interface IRepository<TEntity, in TKey> where TEntity : IAggregateRoot, IBaseEntity<TKey>
{
    Task<IReadOnlyCollection<TEntity>> ListAsync(ISpecification<TEntity> specification);

    Task<PagedResponse<TEntity>> ListAsPageAsync(ISpecification<TEntity> specification);

    // Note: we can't add includes in this case...
    Task<TEntity> GetByIdAsync(TKey id);

    // Note: sorting has no meaning in this context
    Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity> specification);

    Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity> specification);

    Task<TEntity> GetFirstOrDefaultAsync(TKey id);

    Task<int> CountAsync(ISpecification<TEntity> specification);

    Task<bool> AnyAsync(ISpecification<TEntity> specification);

    void Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void UpdateRange(IEnumerable<TEntity> entity);

    void Delete(TEntity entity);

    void Delete(TKey id);

    void DeleteRange(IEnumerable<TKey> ids);

    void Delete(ISpecification<TEntity> specification);
}