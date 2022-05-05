using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Catalog.Core.Generic.Models;
using MultiTenant.Catalog.Domain.Common;
using MultiTenant.Catalog.Infrastructure.Common.Pagination;

namespace MultiTenant.Catalog.Infrastructure.Common.Specifications;

internal static class SpecificationExtensions
{
    private static readonly MethodInfo IncludeMethodInfo = GetIncludeMethodInfo();

    private static readonly MethodInfo ThenIncludeOfIEnumerableMethodInfo =
        GetThenIncludeOfIEnumerableMethodInfo();

    private static readonly MethodInfo ThenIncludeMethodInfo = GetThenIncludeMethodInfo();

    public static IQueryable<TEntity> UseCriteria<TEntity>(
        this IQueryable<TEntity> query, ISpecification<TEntity> specification)
        where TEntity : IAggregateRoot
    {
        var result = specification.GetPredicates()
            .Aggregate(
                query,
                (current, specificationCriterion) => current.Where(specificationCriterion));
        return result;
    }

    public static IQueryable<TEntity> Use<TEntity>(
        this IQueryable<TEntity> query, ISpecification<TEntity> specification)
        where TEntity : IAggregateRoot
    {
        return query.UseCriteria(specification)
            .AddSorting(specification.GetSorts().ToArray())
            .AddIncludes(specification);
    }

    public static Task<PagedResponse<TEntity>> AsPagedResponseAsync<TEntity>(
        this IQueryable<TEntity> query, ISpecification<TEntity> specification)
        where TEntity : IAggregateRoot
    {
        return Task.FromResult(query.Use(specification)
            .AsPagedResponse(specification.PagingOptions));
    }

    private static IQueryable<TEntity> AddIncludes<TEntity>(
        this IQueryable<TEntity> query,
        ISpecification<TEntity> specification)
        where TEntity : IAggregateRoot
    {
        var includableSpecification = specification;

        var resultQuery = query as object;
        foreach (var include in includableSpecification.GetIncludes())
        {
            resultQuery = IncludeMethodInfo.MakeGenericMethod(include.EntityType, include.PropertyType)
                .Invoke(null, new[] { resultQuery, include.IncludeExpression });
            var subNode = include;
            while ((subNode = subNode.SubNode) != null)
                if (subNode.ForIEnumerable)
                    resultQuery = ThenIncludeOfIEnumerableMethodInfo.MakeGenericMethod(
                            subNode.EntityType,
                            subNode.PreviousPropertyType!,
                            subNode.PropertyType)
                        .Invoke(null, new[] { resultQuery, subNode.IncludeExpression });
                else
                    resultQuery = ThenIncludeMethodInfo.MakeGenericMethod(
                            subNode.EntityType,
                            subNode.PreviousPropertyType!,
                            subNode.PropertyType)
                        .Invoke(null, new[] { resultQuery, subNode.IncludeExpression });
        }

        return (IQueryable<TEntity>)resultQuery!;
    }

    private static MethodInfo GetIncludeMethodInfo()
    {
        return typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods("Include")
            .Single(mi => mi.GetGenericArguments().Length == 2);
    }

    private static MethodInfo GetThenIncludeOfIEnumerableMethodInfo()
    {
        return typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods("ThenInclude")
            .Where(mi => mi.GetGenericArguments().Length == 3)
            .Single(mi =>
            {
                var type = mi.GetParameters()[0]
                    .ParameterType.GenericTypeArguments[1]
                    .GetTypeInfo();
                return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
            });
    }

    private static MethodInfo GetThenIncludeMethodInfo()
    {
        return typeof(EntityFrameworkQueryableExtensions)
            .GetTypeInfo()
            .GetDeclaredMethods("ThenInclude")
            .Where(mi => mi.GetGenericArguments().Length == 3)
            .Single(mi =>
                mi.GetParameters()[0]
                    .ParameterType.GenericTypeArguments[1]
                    .GetTypeInfo()
                    .IsGenericType == false);
    }
}