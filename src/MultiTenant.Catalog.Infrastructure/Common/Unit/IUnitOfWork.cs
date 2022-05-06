namespace MultiTenant.Catalog.Infrastructure.Common.Unit;

public interface IUnitOfWork
{
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default, bool isConcurrency = false);
}