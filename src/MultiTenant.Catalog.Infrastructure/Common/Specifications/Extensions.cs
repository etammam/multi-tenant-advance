using System.Linq.Expressions;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Infrastructure.Common.Helpers;
using MultiTenant.Catalog.Infrastructure.Common.Pagination;
using MultiTenant.Catalog.Infrastructure.Common.Specifications.Includes;
using MultiTenant.Catalog.Infrastructure.Common.Specifications.Sorting;

namespace MultiTenant.Catalog.Infrastructure.Common.Specifications;

public static class Extensions
{
    public static IIncludableSpecification<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludableSpecification<TEntity, IEnumerable<TPreviousProperty>> specification,
        Expression<Func<TPreviousProperty, TProperty>> include)
        where TEntity : IAggregateRoot
    {
        var includeNode = new IncludeNode(include, typeof(TEntity), typeof(TProperty), typeof(TPreviousProperty), true);
        specification.GetIncludeNode().SubNode = includeNode;
        return new IncludableSpecification<TEntity, TProperty>(
            specification, includeNode);
    }

    public static IIncludableSpecification<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
        this IIncludableSpecification<TEntity, TPreviousProperty> specification,
        Expression<Func<TPreviousProperty, TProperty>> include)
        where TEntity : IAggregateRoot
    {
        var includeNode = new IncludeNode(include, typeof(TEntity), typeof(TProperty), typeof(TPreviousProperty));
        specification.GetIncludeNode().SubNode = includeNode;
        return new IncludableSpecification<TEntity, TProperty>(
            specification, includeNode);
    }

    public static IQueryable<TEntity> UsePaging<TEntity>(
        this IQueryable<TEntity> query, PagingOptions pagingOptions)
    {
        var skip = (pagingOptions.PageNumber - 1) * pagingOptions.PageSize;
        var result = query.Skip(skip)
            .Take(pagingOptions.PageSize);
        return result;
    }

    public static IQueryable<TEntity> AddSorting<TEntity>(
        this IQueryable<TEntity> source,
        params SortingField[] sortings)
    {
        if (!sortings.Any() || sortings.Select(sort => sort).FirstOrDefault() == null) return source;

        var strongSortings = sortings.Select(sorting => new SortingField<TEntity>(sorting))
            .ToArray();
        return source.AddSorting(strongSortings);
    }

    public static IQueryable<TEntity> AddSorting<TEntity>(
        this IQueryable<TEntity> source,
        SortingField sorting)
    {
        return source.AddSorting(new[] { sorting });
    }

    public static IQueryable<TEntity> AddFilter<TEntity>(this IQueryable<TEntity> source, string filter)
    {
        if (!string.IsNullOrWhiteSpace(filter))
        {
            var filterExpression = ExpressionHelper.GetSelectorExpression<TEntity, bool>(filter);
            return source.Where(filterExpression);
        }

        return source;
    }

    internal static IQueryable<TEntity> AddSorting<TEntity>(
        this IQueryable<TEntity> source,
        params SortingField<TEntity>[] sortings)
    {
        if (!sortings.Any()) return source;

        var firstSorting = sortings.First();
        var result = firstSorting.Direction == SortDirection.Ascending
            ? source.OrderBy(firstSorting.Field)
            : source.OrderByDescending(firstSorting.Field);

        return sortings.Skip(1)
            .Aggregate(result, (current, sorting) => sorting.Direction == SortDirection.Ascending
                ? current.ThenBy(sorting.Field)
                : current.ThenByDescending(sorting.Field));
    }
}