using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Core.Services;

public interface IBusinessService
{
    Task<List<BusinessContract>> GetListAsync();
    Task<BusinessContract> GetAsync(Guid businessId);
    Task<BusinessContract> CreateAsync(BusinessContract model);
    Task<BusinessContract> UpdateAsync(BusinessContract model);
    Task<bool> DeleteAsync(Guid businessId);
}