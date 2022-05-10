﻿namespace MultiTenant.Catalog.Core.Generic.Models;

public class PagedResponse<TResponseList>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public Uri? FirstPage { get; set; }
    public Uri? LastPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public Uri? NextPage { get; set; }
    public Uri? PreviousPage { get; set; }
    public List<TResponseList>? Items { get; set; }
}