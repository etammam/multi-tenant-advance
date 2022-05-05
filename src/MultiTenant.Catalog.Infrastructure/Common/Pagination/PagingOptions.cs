namespace MultiTenant.Catalog.Infrastructure.Common.Pagination;

public class PagingOptions
{
    public PagingOptions()
    {
    }

    public PagingOptions(int pageSize, int pageNumber)
    {
        PageSize = pageSize;
        PageNumber = pageNumber;
    }

    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}