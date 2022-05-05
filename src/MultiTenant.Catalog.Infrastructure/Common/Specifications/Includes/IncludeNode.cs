using System.Linq.Expressions;

namespace MultiTenant.Catalog.Infrastructure.Common.Specifications.Includes;

public class IncludeNode
{
    public IncludeNode(
        Expression includeExpression,
        Type entityType,
        Type propertyType,
        Type previousPropertyType = null,
        bool forIEnumerable = false)
    {
        IncludeExpression = includeExpression;
        EntityType = entityType;
        PropertyType = propertyType;
        PreviousPropertyType = previousPropertyType;
        ForIEnumerable = forIEnumerable;
    }

    public Type EntityType { get; }

    public Type PropertyType { get; }

    public Type PreviousPropertyType { get; }

    public bool ForIEnumerable { get; }

    public Expression IncludeExpression { get; }

    public IncludeNode SubNode { get; set; }
}