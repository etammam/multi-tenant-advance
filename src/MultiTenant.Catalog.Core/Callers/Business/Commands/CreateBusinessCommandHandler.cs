using AutoMapper;
using MediatR;
using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Core.Services;

namespace MultiTenant.Catalog.Core.Callers.Business.Commands;

public class CreateBusinessCommandHandler : IRequestHandler<CreateBusinessCommand, BusinessContract>
{
    private readonly IBusinessService _businessService;
    private readonly IMapper _mapper;

    public CreateBusinessCommandHandler(IBusinessService businessService, IMapper mapper)
    {
        _businessService = businessService;
        _mapper = mapper;
    }

    public async Task<BusinessContract> Handle(CreateBusinessCommand request, CancellationToken cancellationToken)
    {
        var model = _mapper.Map<BusinessContract>(request);
        var result = await _businessService.CreateAsync(model);
        return result;
    }
}