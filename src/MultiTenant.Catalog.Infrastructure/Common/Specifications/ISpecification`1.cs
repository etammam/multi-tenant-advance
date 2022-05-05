using System.Linq.Expressions;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Infrastructure.Common.Pagination;
using MultiTenant.Catalog.Infrastructure.Common.Specifications.Includes;
using MultiTenant.Catalog.Infrastructure.Common.Specifications.Sorting;

namespace MultiTenant.Catalog.Infrastructure.Common.Specifications;

public interface ISpecification<TEntity>
    where TEntity : IAggregateRoot
{
    PagingOptions PagingOptions { get; set; }

    IReadOnlyCollection<Expression<Func<TEntity, bool>>> GetPredicates();

    IReadOnlyCollection<SortingField<TEntity>> GetSorts();

    IReadOnlyCollection<IncludeNode> GetIncludes();

    ISpecification<TEntity> AddSorting(Expression<Func<TEntity, object>> field, SortDirection sortDirection);

    ISpecification<TEntity> AddSorting(SortingField sorting);

    ISpecification<TEntity> AddPagingOptions(PagingOptions pagingOptions);

    IIncludableSpecification<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> include);

    ISpecification<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

    ISpecification<TEntity> AddFiltering(string filter);
}