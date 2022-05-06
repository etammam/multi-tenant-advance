using MediatR;
using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Core.Services;

namespace MultiTenant.Catalog.Core.Callers.Business.Queries;

public class GetBusinessQueryHandler : IRequestHandler<GetBusinessQuery, BusinessContract>
{
    private readonly IBusinessService _businessService;

    public GetBusinessQueryHandler(IBusinessService businessService)
    {
        _businessService = businessService;
    }

    /// <summary>Handles a request</summary>
    /// <param name="request">The request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Response from the request</returns>
    public async Task<BusinessContract> Handle(GetBusinessQuery request, CancellationToken cancellationToken)
    {
        var result = await _businessService.GetAsync(request.GetId);
        return result;
    }
}