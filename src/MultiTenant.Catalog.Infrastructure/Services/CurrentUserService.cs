using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using MultiTenant.Catalog.Core.Common;

namespace MultiTenant.Catalog.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITokenService _tokenService;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, ITokenService tokenService)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenService = tokenService;
    }

    public Guid UserId()
    {
        if (_httpContextAccessor.HttpContext != null && IsAuthenticated())
        {
            var currentAccessToken =
                _httpContextAccessor.HttpContext?.Request.Headers
                    .FirstOrDefault(c => c.Key == HeaderNames.Authorization)
                    .ToString()
                    .Remove(0, 7);
            var userClaims = _tokenService.DecodeJwtToken(currentAccessToken!);
            var claims = userClaims.Item2.Claims;
            return Guid.Parse(claims.FirstOrDefault(d => d.Type == ClaimTypes.NameIdentifier)?.Value!);
        }

        return Guid.Empty;
    }

    public string UserName()
    {
        if (_httpContextAccessor.HttpContext != null && IsAuthenticated())
        {
            var currentAccessToken =
                _httpContextAccessor.HttpContext?.Request.Headers
                    .FirstOrDefault(c => c.Key == HeaderNames.Authorization)
                    .ToString()
                    .Remove(0, 7);
            var userClaims = _tokenService.DecodeJwtToken(currentAccessToken!);
            var claims = userClaims.Item2.Claims;
            return claims.FirstOrDefault(d => d.Type == ClaimTypes.GivenName)?.Value;
        }

        return string.Empty;
    }

    public string GetName()
    {
        if (_httpContextAccessor.HttpContext != null && IsAuthenticated())
        {
            var currentAccessToken =
                _httpContextAccessor.HttpContext?.Request.Headers
                    .FirstOrDefault(c => c.Key == HeaderNames.Authorization)
                    .ToString()
                    .Remove(0, 7);
            var userClaims = _tokenService.DecodeJwtToken(currentAccessToken!);
            var claims = userClaims.Item2.Claims;
            return claims.FirstOrDefault(d => d.Type == ClaimTypes.Name)?.Value;
        }

        return string.Empty;
    }

    private bool IsAuthenticated()
    {
        return !string.IsNullOrWhiteSpace(_httpContextAccessor.HttpContext?.Request.Headers
            .FirstOrDefault(c => c.Key == HeaderNames.Authorization)
            .Value);
    }
}