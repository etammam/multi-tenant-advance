using MediatR;

namespace MultiTenant.Catalog.Core.Callers.Business.Commands;

public class DeleteBusinessCommand : IRequest<bool>
{
    public DeleteBusinessCommand(Guid id)
    {
        Id = id;
    }

    private Guid Id { get; }
    public Guid GetId => Id;
}