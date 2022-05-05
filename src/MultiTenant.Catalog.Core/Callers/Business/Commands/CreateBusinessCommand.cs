using MediatR;
using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Core.Callers.Business.Commands;

public class CreateBusinessCommand : IRequest<BusinessContract>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}