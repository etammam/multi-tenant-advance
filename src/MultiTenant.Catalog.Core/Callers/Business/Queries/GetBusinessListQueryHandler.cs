using MediatR;
using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Core.Services;

namespace MultiTenant.Catalog.Core.Callers.Business.Queries;

public class GetBusinessListQueryHandler : IRequestHandler<GetBusinessListQuery, List<BusinessContract>>
{
    private readonly IBusinessService _businessService;

    public GetBusinessListQueryHandler(IBusinessService businessService)
    {
        _businessService = businessService;
    }

    public async Task<List<BusinessContract>> Handle(GetBusinessListQuery request, CancellationToken cancellationToken)
    {
        var result = await _businessService.GetListAsync();
        return result;
    }
}