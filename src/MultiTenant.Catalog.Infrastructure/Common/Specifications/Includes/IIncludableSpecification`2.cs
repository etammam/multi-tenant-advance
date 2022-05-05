using MultiTenant.Catalog.Domain.Common;

namespace MultiTenant.Catalog.Infrastructure.Common.Specifications.Includes;

public interface IIncludableSpecification<TEntity, out TProperty> : ISpecification<TEntity>
    where TEntity : IAggregateRoot
{
    IncludeNode GetIncludeNode();
}