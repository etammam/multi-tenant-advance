using MediatR;
using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Core.Callers.Business.Queries;

public class GetBusinessQuery : IRequest<BusinessContract>
{
    public GetBusinessQuery(Guid id)
    {
        Id = id;
    }

    private Guid Id { get; }
    public Guid GetId => Id;
}