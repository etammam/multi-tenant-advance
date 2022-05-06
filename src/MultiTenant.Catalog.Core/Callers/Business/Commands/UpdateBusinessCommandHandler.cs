using AutoMapper;
using MediatR;
using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Core.Services;

namespace MultiTenant.Catalog.Core.Callers.Business.Commands;

public class UpdateBusinessCommandHandler : IRequestHandler<UpdateBusinessCommand, BusinessContract>
{
    private readonly IBusinessService _businessService;
    private readonly IMapper _mapper;

    public UpdateBusinessCommandHandler(IBusinessService businessService, IMapper mapper)
    {
        _businessService = businessService;
        _mapper = mapper;
    }

    public async Task<BusinessContract> Handle(UpdateBusinessCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<BusinessContract>(request);
        var result = await _businessService.UpdateAsync(model);
        return result;
    }
}