namespace MultiTenant.Catalog.Infrastructure.Common.Unit;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default, bool isConcurrency = false);
}