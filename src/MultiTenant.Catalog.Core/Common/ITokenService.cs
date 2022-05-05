using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Core.Common;

public interface ITokenService
{
    IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }
    AuthenticationResult GenerateTokens(string email, Claim[] claims, DateTime now);
    AuthenticationResult Refresh(string refreshToken, string accessToken, DateTime now);
    void RemoveExpiredRefreshTokens(DateTime now);
    void RemoveRefreshTokenByUserName(string userName);
    (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
}