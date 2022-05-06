using MediatR;
using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Core.Callers.Business.Queries;

public class GetBusinessListQuery : IRequest<List<BusinessContract>>
{
}