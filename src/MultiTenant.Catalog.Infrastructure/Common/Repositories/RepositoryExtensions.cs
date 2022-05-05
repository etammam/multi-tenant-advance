using System.Linq.Expressions;
using MultiTenant.Catalog.Core.Generic.Models;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Infrastructure.Common.Pagination;
using MultiTenant.Catalog.Infrastructure.Common.Specifications;

namespace MultiTenant.Catalog.Infrastructure.Common.Repositories;

public static class RepositoryExtensions
{
    public static Task<IReadOnlyCollection<TEntity>> GetAllAsync<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository,
        Expression<Func<TEntity, bool>> criteria)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        var specification = new Specification<TEntity>(criteria);
        return repository.ListAsync(specification);
    }

    public static Task<PagedResponse<TEntity>> ListAsync<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository,
        Expression<Func<TEntity, bool>> criteria,
        PagingOptions paging)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        var specification = new Specification<TEntity>(criteria)
        {
            PagingOptions = paging
        };
        return repository.ListAsPageAsync(specification);
    }

    public static Task<PagedResponse<TEntity>> ListAsPageAsync<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository,
        PagingOptions paging)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        var specification = new Specification<TEntity>
        {
            PagingOptions = paging
        };
        return repository.ListAsPageAsync(specification);
    }

    public static Task<IReadOnlyCollection<TEntity>> ListAsync<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        return repository.ListAsync(new Specification<TEntity>());
    }

    public static Task<TEntity> GetSingleOrDefaultAsync<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository,
        Expression<Func<TEntity, bool>> criteria)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        return repository.GetSingleOrDefaultAsync(new Specification<TEntity>(criteria));
    }

    public static Task<TEntity> GetFirstOrDefaultAsync<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository,
        Expression<Func<TEntity, bool>> criteria)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        return repository.GetFirstOrDefaultAsync(new Specification<TEntity>(criteria));
    }

    public static Task<TEntity> GetFirstOrDefaultAsync<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        return repository.GetFirstOrDefaultAsync(new Specification<TEntity>());
    }

    public static Task<int> CountAsync<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository,
        Expression<Func<TEntity, bool>> criteria)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        return repository.CountAsync(new Specification<TEntity>(criteria));
    }

    public static Task<int> CountAsync<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        return repository.CountAsync(new Specification<TEntity>());
    }

    public static Task<bool> AnyAsync<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository,
        Expression<Func<TEntity, bool>> criteria)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        return repository.AnyAsync(new Specification<TEntity>(criteria));
    }

    public static Task<bool> AnyAsync<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> repository)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        return repository.AnyAsync(new Specification<TEntity>());
    }

    public static void Delete<TEntity, TPrimaryKey>(
        this IRepository<TEntity, TPrimaryKey> repository,
        Expression<Func<TEntity, bool>> criteria)
        where TEntity : class, IBaseEntity<TPrimaryKey>, IAggregateRoot
    {
        repository.Delete(new Specification<TEntity>(criteria));
    }
}