using System.Linq.Expressions;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Infrastructure.Common.Pagination;
using MultiTenant.Catalog.Infrastructure.Common.Specifications.Sorting;

namespace MultiTenant.Catalog.Infrastructure.Common.Specifications.Includes;

internal class IncludableSpecification<TEntity, TProperty> : IIncludableSpecification<TEntity, TProperty>
    where TEntity : IAggregateRoot
{
    private readonly IncludeNode _includeNode;
    private readonly ISpecification<TEntity> _previousSpecification;

    public IncludableSpecification(
        ISpecification<TEntity> previousSpecification,
        IncludeNode includeNode)
    {
        _previousSpecification = previousSpecification;
        _includeNode = includeNode;
    }

    public PagingOptions PagingOptions
    {
        get => _previousSpecification.PagingOptions;
        set => _previousSpecification.PagingOptions = value;
    }

    public IncludeNode GetIncludeNode()
    {
        return _includeNode;
    }

    public IReadOnlyCollection<Expression<Func<TEntity, bool>>> GetPredicates()
    {
        return _previousSpecification.GetPredicates();
    }

    public IReadOnlyCollection<SortingField<TEntity>> GetSorts()
    {
        return _previousSpecification.GetSorts();
    }

    public ISpecification<TEntity> AddSorting(Expression<Func<TEntity, object>> field, SortDirection sortDirection)
    {
        return _previousSpecification.AddSorting(field, sortDirection);
    }

    public ISpecification<TEntity> AddSorting(SortingField sorting)
    {
        return _previousSpecification.AddSorting(sorting);
    }

    public ISpecification<TEntity> AddPagingOptions(PagingOptions pagingOptions)
    {
        return _previousSpecification.AddPagingOptions(pagingOptions);
    }

    public IIncludableSpecification<TEntity, TRootProperty> Include<TRootProperty>(
        Expression<Func<TEntity, TRootProperty>> include)
    {
        return _previousSpecification.Include(include);
    }

    public ISpecification<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return _previousSpecification.Where(predicate);
    }

    public IReadOnlyCollection<IncludeNode> GetIncludes()
    {
        return _previousSpecification.GetIncludes();
    }

    public ISpecification<TEntity> AddFiltering(string filter)
    {
        return _previousSpecification.AddFiltering(filter);
    }
}