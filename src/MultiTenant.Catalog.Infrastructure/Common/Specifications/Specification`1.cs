using System.Linq.Expressions;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Infrastructure.Common.Helpers;
using MultiTenant.Catalog.Infrastructure.Common.Pagination;
using MultiTenant.Catalog.Infrastructure.Common.Specifications.Includes;
using MultiTenant.Catalog.Infrastructure.Common.Specifications.Sorting;

namespace MultiTenant.Catalog.Infrastructure.Common.Specifications;

public class Specification<TEntity> : ISpecification<TEntity>
    where TEntity : IAggregateRoot
{
    private readonly List<Expression<Func<TEntity, bool>>> _criteria = new();
    private readonly List<IncludeNode> _includeNodes = new();
    private readonly List<SortingField<TEntity>> _sortingFields = new();

    protected internal Specification(Expression<Func<TEntity, bool>> criteria)
    {
        _criteria.Add(criteria);
    }

    protected internal Specification()
    {
    }

    public PagingOptions PagingOptions { get; set; }

    public IReadOnlyCollection<SortingField<TEntity>> GetSorts()
    {
        return _sortingFields.AsReadOnly();
    }

    public IReadOnlyCollection<Expression<Func<TEntity, bool>>> GetPredicates()
    {
        return _criteria.AsReadOnly();
    }

    public IReadOnlyCollection<IncludeNode> GetIncludes()
    {
        return _includeNodes.AsReadOnly();
    }

    public ISpecification<TEntity> AddSorting(Expression<Func<TEntity, object>> field, SortDirection sortDirection)
    {
        var sorting = new SortingField<TEntity>(field, sortDirection);
        _sortingFields.Add(sorting);
        return this;
    }

    public ISpecification<TEntity> AddPagingOptions(PagingOptions pagingOptions)
    {
        if (pagingOptions != null) PagingOptions = pagingOptions;
        return this;
    }

    public ISpecification<TEntity> AddSorting(SortingField sorting)
    {
        if (sorting != null) _sortingFields.Add(new SortingField<TEntity>(sorting));

        return this;
    }

    /// <summary>
    ///     allow string filtration we could pass expression as string
    /// </summary>
    /// <param name="filter">expression as string </param>
    /// <example>
    ///     <code>
    /// Specification.AddFiltering("number => number > 3");
    /// Specification.AddFiltering("flag => flag == true");
    /// Specification.AddFiltering(appointment=> appointment.Date > DateTime(2019, 09, 11))
    /// </code>
    /// </example>
    public ISpecification<TEntity> AddFiltering(string filter)
    {
        if (!string.IsNullOrWhiteSpace(filter))
        {
            var filtrationCriteria = ExpressionHelper.GetSelectorExpression<TEntity, bool>(filter);
            _criteria.Add(filtrationCriteria);
        }

        return this;
    }

    public IIncludableSpecification<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> include)
    {
        var includeNode = new IncludeNode(include, typeof(TEntity), typeof(TProperty));
        _includeNodes.Add(includeNode);
        return new IncludableSpecification<TEntity, TProperty>(this, includeNode);
    }

    public ISpecification<TEntity> Where(Expression<Func<TEntity, bool>> criteria)
    {
        _criteria.Add(criteria);
        return this;
    }
}