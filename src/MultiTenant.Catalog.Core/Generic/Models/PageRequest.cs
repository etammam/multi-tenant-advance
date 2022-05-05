namespace MultiTenant.Catalog.Core.Generic.Models;

public class PageRequest
{
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
}