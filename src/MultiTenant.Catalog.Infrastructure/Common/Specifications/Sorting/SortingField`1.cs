using System.Linq.Expressions;
using MultiTenant.Catalog.Infrastructure.Common.Helpers;

namespace MultiTenant.Catalog.Infrastructure.Common.Specifications.Sorting;

public class SortingField<TEntity>
{
    public SortingField(Expression<Func<TEntity, object>> field, SortDirection sortDirection)
    {
        Field = field;
        Direction = sortDirection;
    }

    public SortingField(SortingField sorting)
        : this(ExpressionHelper.GetSelectorExpression<TEntity, object>(sorting.Field), sorting.Direction)
    {
    }

    public Expression<Func<TEntity, object>> Field { get; }

    public SortDirection Direction { get; }
}