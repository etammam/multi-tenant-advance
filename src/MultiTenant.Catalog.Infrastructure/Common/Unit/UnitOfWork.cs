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

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default,
        bool isConcurrency = false)
    {
        var result = 0;
        if (!isConcurrency)
            result = await _databaseContext.SaveChangesAsync(cancellationToken);
        else
            try
            {
                await _databaseContext.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await ex.Entries.Single().ReloadAsync(cancellationToken);
                await _databaseContext.SaveChangesAsync(cancellationToken);
            }

        return result;
    }
}