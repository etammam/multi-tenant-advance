namespace MultiTenant.Catalog.Infrastructure.Common.Specifications.Sorting;

public class SortingField
{
    public SortingField(string field, SortDirection direction)
    {
        Field = field;
        Direction = direction;
    }

    public SortingField()
    {
    }

    public string Field { get; set; }

    public SortDirection Direction { get; set; }
}