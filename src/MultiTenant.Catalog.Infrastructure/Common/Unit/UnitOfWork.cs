using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Infrastructure.Persistence;

namespace MultiTenant.Catalog.Infrastructure.Common.Unit;

public class UnitOfWork : IUnitOfWork
{
    private readonly ICatalogContext _databaseContext;

    public UnitOfWork(ICatalogContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default,
        bool isConcurrency = false)
    {
        bool result;
        if (!isConcurrency)
            result = await _databaseContext.SaveChangesAsync(cancellationToken) > 0;
        else
            try
            {
                result = await _databaseContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await ex.Entries.Single().ReloadAsync(cancellationToken);
                result = await _databaseContext.SaveChangesAsync(cancellationToken) > 0;
            }

        return result;
    }
}