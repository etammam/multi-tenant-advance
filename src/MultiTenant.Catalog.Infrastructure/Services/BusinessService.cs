using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Core.Services;

namespace MultiTenant.Catalog.Infrastructure.Services;

public class BusinessService : IBusinessService
{
    public Task<List<BusinessContract>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<BusinessContract> GetAsync(Guid businessId)
    {
        throw new NotImplementedException();
    }

    public Task<BusinessContract> CreateAsync(BusinessContract model)
    {
        throw new NotImplementedException();
    }

    public Task<BusinessContract> UpdateAsync(BusinessContract model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid businessId)
    {
        throw new NotImplementedException();
    }
}