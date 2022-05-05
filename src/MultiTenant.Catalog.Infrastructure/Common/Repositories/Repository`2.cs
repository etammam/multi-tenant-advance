using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Core.Generic.Models;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Infrastructure.Common.Specifications;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Common.Repositories;

public class Repository<TEntity, TKey>
    : IRepository<TEntity, TKey>
    where TEntity : class, IAggregateRoot, IBaseEntity<TKey>
{
    private readonly ICatalogContext _context;

    public Repository(ICatalogContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<TEntity>> ListAsync(ISpecification<TEntity> specification)
    {
        return await _context.Set<TEntity>().Use(specification).ToArrayAsync();
    }

    public Task<PagedResponse<TEntity>> ListAsPageAsync(ISpecification<TEntity> specification)
    {
        return _context.Set<TEntity>().AsPagedResponseAsync(specification);
    }

    public Task<TEntity> GetByIdAsync(TKey id)
    {
        return _context.Set<TEntity>().FindAsync(id).AsTask();
    }

    public Task<TEntity> GetSingleOrDefaultAsync(ISpecification<TEntity> specification)
    {
        return _context.Set<TEntity>().Use(specification)
            .SingleOrDefaultAsync();
    }

    public Task<TEntity> GetFirstOrDefaultAsync(ISpecification<TEntity> specification)
    {
        return _context.Set<TEntity>().Use(specification)
            .FirstOrDefaultAsync();
    }

    public Task<TEntity> GetFirstOrDefaultAsync(TKey id)
    {
        return _context.Set<TEntity>()
            .FirstOrDefaultAsync(p => id != null && p.Id != null && p.Id.ToString == id.ToString);
    }

    public Task<int> CountAsync(ISpecification<TEntity> specification)
    {
        return _context.Set<TEntity>().UseCriteria(specification)
            .CountAsync();
    }

    public Task<bool> AnyAsync(ISpecification<TEntity> specification)
    {
        return _context.Set<TEntity>().UseCriteria(specification)
            .AnyAsync();
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        var trackedEntity = _context.Set<TEntity>().Local.FirstOrDefault(e => e.Id != null && e.Id.Equals(entity.Id));

        if (trackedEntity != null)
            _context.Entry(trackedEntity).CurrentValues.SetValues(entity);
        else
            _context.Set<TEntity>().Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities) Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void Delete(TKey id)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity != null) Delete(entity);
    }

    public void DeleteRange(IEnumerable<TKey> ids)
    {
        _context.Set<TEntity>().Where(entity => ids.Contains(entity.Id))
            .ToList()
            .ForEach(Delete);
    }

    public void Delete(ISpecification<TEntity> specification)
    {
        _context.Set<TEntity>().UseCriteria(specification)
            .ToList()
            .ForEach(Delete);
    }

    public void AddAsync(TEntity entity)
    {
        _context.Set<TEntity>().AddAsync(entity);
    }

    public void AddRangeAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().AddRangeAsync(entities);
    }
}