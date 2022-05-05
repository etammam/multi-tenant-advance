using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using MultiTenant.Catalog.Core.Generic.Models;

namespace MultiTenant.Catalog.Infrastructure.Common.Pagination;

public static class PaginationHelper
{
    private static IHttpContextAccessor _httpContextAccessor;

    internal static void AddHttpContextAccessor(IHttpContextAccessor accessor)
    {
        _httpContextAccessor = accessor;
    }

    private static string GetBaseUrl()
    {
        var request = _httpContextAccessor.HttpContext?.Request;
        var uri = string.Concat(request?.Scheme, "://", request?.Host.ToUriComponent());
        return uri;
    }

    public static Uri GetPageUri(int pageSize, int pageNumber, string route)
    {
        if (!string.IsNullOrEmpty(route))
        {
            var baseUri = GetBaseUrl();
            var endpointUri = new Uri(string.Concat(baseUri, '/', route));
            var modifiedUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "pageNumber", pageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pageSize.ToString());
            return new Uri(modifiedUri);
        }

        return null;
    }

    public static PagedResponse<T> AsPagedResponse<T>(this List<T> items, int pageSize = 10, int pageNumber = 1,
        string apiRoute = null)
    {
        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));
        if (pageNumber <= 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
        var totalRecords = items.Count;
        var totalPages = (double)totalRecords / pageSize;
        var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        var nextPage =
            pageNumber < roundedTotalPages
                ? GetPageUri(pageNumber + 1, pageSize, apiRoute)
                : null;
        var previousPage =
            pageNumber - 1 >= 1 && pageNumber <= roundedTotalPages
                ? GetPageUri(pageNumber - 1, pageSize, apiRoute)
                : null;
        var firstPage = GetPageUri(1, pageSize, apiRoute);
        var lastPage = GetPageUri(roundedTotalPages, pageSize, apiRoute);
        var selectedItems = items.Skip(pageNumber - 1 * pageSize).Take(pageSize);

        return new PagedResponse<T>
        {
            FirstPage = firstPage,
            LastPage = lastPage,
            NextPage = nextPage,
            PreviousPage = previousPage,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = totalRecords,
            TotalPages = Convert.ToInt32(totalPages),
            Items = selectedItems.ToList()
        };
    }

    public static PagedResponse<T> AsPagedResponse<T>(this List<T> items, PagingOptions options,
        string apiRoute = null)
    {
        var pageSize = options.PageSize;
        var pageNumber = options.PageNumber;

        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));
        if (pageNumber <= 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
        var totalRecords = items.Count;
        var totalPages = (double)totalRecords / pageSize;
        var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        var nextPage =
            pageNumber < roundedTotalPages
                ? GetPageUri(pageNumber + 1, pageSize, apiRoute)
                : null;
        var previousPage =
            pageNumber - 1 >= 1 && pageNumber <= roundedTotalPages
                ? GetPageUri(pageNumber - 1, pageSize, apiRoute)
                : null;
        var firstPage = GetPageUri(1, pageSize, apiRoute);
        var lastPage = GetPageUri(roundedTotalPages, pageSize, apiRoute);
        var selectedItems = items.Skip(pageNumber - 1 * pageSize).Take(pageSize);

        return new PagedResponse<T>
        {
            FirstPage = firstPage,
            LastPage = lastPage,
            NextPage = nextPage,
            PreviousPage = previousPage,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = totalRecords,
            TotalPages = Convert.ToInt32(totalPages),
            Items = selectedItems.ToList()
        };
    }

    public static PagedResponse<T> AsPagedResponse<T>(this IQueryable<T> items, PagingOptions options,
        string apiRoute = null)
    {
        var pageSize = options.PageSize;
        var pageNumber = options.PageNumber;

        if (pageSize <= 0) throw new ArgumentOutOfRangeException(nameof(pageSize));
        if (pageNumber <= 0) throw new ArgumentOutOfRangeException(nameof(pageNumber));
        var totalRecords = items.ToList().Count;
        var totalPages = (double)totalRecords / pageSize;
        var roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
        var nextPage =
            pageNumber < roundedTotalPages
                ? GetPageUri(pageNumber + 1, pageSize, apiRoute)
                : null;
        var previousPage =
            pageNumber - 1 >= 1 && pageNumber <= roundedTotalPages
                ? GetPageUri(pageNumber - 1, pageSize, apiRoute)
                : null;
        var firstPage = GetPageUri(1, pageSize, apiRoute);
        var lastPage = GetPageUri(roundedTotalPages, pageSize, apiRoute);
        var selectedItems = items.Skip(pageNumber - 1 * pageSize).Take(pageSize);

        return new PagedResponse<T>
        {
            FirstPage = firstPage,
            LastPage = lastPage,
            NextPage = nextPage,
            PreviousPage = previousPage,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = totalRecords,
            TotalPages = Convert.ToInt32(totalPages),
            Items = selectedItems.ToList()
        };
    }
}