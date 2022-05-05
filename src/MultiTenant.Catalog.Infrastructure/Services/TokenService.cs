using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MultiTenant.Catalog.Core.Common;
using MultiTenant.Catalog.Core.Configurations;
using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Infrastructure.Services;

public class TokenService : ITokenService
{
    private readonly JwtConfigurations _jwtConfigurations;
    private readonly byte[] _secret;
    private readonly ConcurrentDictionary<string, RefreshToken> _usersRefreshTokens;

    public TokenService(IOptions<JwtConfigurations> jwtConfigurations)
    {
        _jwtConfigurations = jwtConfigurations.Value;
        _usersRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
        _secret = Encoding.ASCII.GetBytes(jwtConfigurations.Value.Secret);
    }

    public IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary =>
        _usersRefreshTokens.ToImmutableDictionary();

    public void RemoveExpiredRefreshTokens(DateTime now)
    {
        var expiredTokens = _usersRefreshTokens.Where(x => x.Value.ExpireAt < now).ToList();
        foreach (var expiredToken in expiredTokens) _usersRefreshTokens.TryRemove(expiredToken.Key, out _);
    }

    public void RemoveRefreshTokenByUserName(string userName)
    {
        var refreshTokens = _usersRefreshTokens.Where(x => x.Value.UserName == userName).ToList();
        foreach (var refreshToken in refreshTokens) _usersRefreshTokens.TryRemove(refreshToken.Key, out _);
    }

    public AuthenticationResult GenerateTokens(string email, Claim[] claims, DateTime now)
    {
        var shouldAddAudienceClaim =
            string.IsNullOrWhiteSpace(claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
        var jwtToken = new JwtSecurityToken(
            _jwtConfigurations.Issuer,
            shouldAddAudienceClaim ? _jwtConfigurations.Audience : string.Empty,
            claims,
            expires: now.AddMinutes(_jwtConfigurations.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_secret),
                SecurityAlgorithms.HmacSha256Signature));
        var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

        var refreshToken = new RefreshToken(email, GenerateRefreshTokenString(),
            now.AddMinutes(_jwtConfigurations.RefreshTokenExpiration));

        _usersRefreshTokens.AddOrUpdate(refreshToken.TokenString, refreshToken, (_, _) => refreshToken);

        return new AuthenticationResult(accessToken, refreshToken);
    }

    public AuthenticationResult Refresh(string refreshToken, string accessToken, DateTime now)
    {
        var (principal, jwtToken) = DecodeJwtToken(accessToken);
        if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            throw new SecurityTokenException("Invalid token");
        var userName = principal.Claims.FirstOrDefault(d => d.Type == ClaimTypes.GivenName)?.Value.ToLower();
        if (!_usersRefreshTokens.TryGetValue(refreshToken, out var existingRefreshToken))
            throw new SecurityTokenException("Invalid token");
        if (existingRefreshToken.UserName != userName || existingRefreshToken.ExpireAt < now)
            throw new SecurityTokenException("Invalid token");

        return GenerateTokens(userName, principal.Claims.ToArray(), now);
    }

    public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
    {
        if (string.IsNullOrWhiteSpace(token)) throw new SecurityTokenException("Invalid token");
        var principal = new JwtSecurityTokenHandler()
            .ValidateToken(token,
                new TokenValidationParameters
                {
                    ValidateIssuer = _jwtConfigurations.ValidateIssuer,
                    ValidIssuer = _jwtConfigurations.Issuer,
                    ValidateIssuerSigningKey = _jwtConfigurations.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(_secret),
                    ValidAudience = _jwtConfigurations.Audience,
                    ValidateAudience = _jwtConfigurations.ValidateAudience,
                    ValidateLifetime = _jwtConfigurations.ValidateLifeTime,
                    ClockSkew = TimeSpan.FromMinutes(_jwtConfigurations.ClockSkew)
                },
                out var validatedToken);
        return (principal, validatedToken as JwtSecurityToken)!;
    }

    private static string GenerateRefreshTokenString()
    {
        var randomNumber = new byte[32];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}