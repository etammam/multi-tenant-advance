using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace MultiTenant.Catalog.Infrastructure.Common.Helpers;

public static class ExpressionHelper
{
    public static Expression<Func<TEntity, TResult>> GetSelectorExpression<TEntity, TResult>(
        string selectorExpression)
    {
        var parameterExpression = Expression.Parameter(typeof(TEntity));
        var result =
            (Expression<Func<TEntity, TResult>>)DynamicExpressionParser.ParseLambda(new[] { parameterExpression },
                typeof(TResult), selectorExpression);

        return result;
    }
}