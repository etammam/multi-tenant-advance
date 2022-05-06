using MediatR;
using MultiTenant.Catalog.Core.Services;

namespace MultiTenant.Catalog.Core.Callers.Business.Commands;

public class DeleteBusinessCommandHandler : IRequestHandler<DeleteBusinessCommand, bool>
{
    private readonly IBusinessService _businessService;

    public DeleteBusinessCommandHandler(IBusinessService businessService)
    {
        _businessService = businessService;
    }

    public async Task<bool> Handle(DeleteBusinessCommand request, CancellationToken cancellationToken)
    {
        var result = await _businessService.DeleteAsync(request.GetId);
        return result;
    }
}