using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Domain.Entities.Users;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MultiTenant.Catalog.Core.Common;

public interface ITokenService
{
    IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }
    Task<AuthenticationResult> GenerateTokenAsync(User user, Claim[] claims, DateTime now);
    Task<AuthenticationResult> Refresh(string refreshToken, string accessToken, DateTime now);
    void RemoveExpiredRefreshTokens(DateTime now);
    void RemoveRefreshTokenByUserName(string userName);
    (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
}