using System.Text.RegularExpressions;
using Ardalis.GuardClauses;

namespace MultiTenant.Catalog.Domain.Exceptions;

public static class CustomGuards
{
    public static string NotEmailAddress(this IGuardClause guard, string input, string parameterName)
    {
        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        var match = regex.Match(input);
        if (!match.Success)
            throw new ArgumentException("given input not match any email address", parameterName);

        return input;
    }

    public static string NotUrl(this IGuardClause guard, string input, string parameterName)
    {
        if (!input.StartsWith("http"))
            throw new InvalidUrlException(parameterName);

        return input;
    }
}