namespace MultiTenant.Catalog.Core.Configurations;

public class JwtConfigurations
{
    public JwtConfigurations()
    {
    }

    public JwtConfigurations(string secret, string issuer, string audience, bool validateIssuer, bool validateAudience,
        bool validateLifeTime, bool validateIssuerSigningKey, int accessTokenExpiration, int refreshTokenExpiration,
        int clockSkew)
    {
        Secret = secret;
        Issuer = issuer;
        Audience = audience;
        ValidateIssuer = validateIssuer;
        ValidateAudience = validateAudience;
        ValidateLifeTime = validateLifeTime;
        ValidateIssuerSigningKey = validateIssuerSigningKey;
        AccessTokenExpiration = accessTokenExpiration;
        RefreshTokenExpiration = refreshTokenExpiration;
        ClockSkew = clockSkew;
    }

    public string Secret { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateLifeTime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
    public int AccessTokenExpiration { get; set; }
    public int RefreshTokenExpiration { get; set; }
    public int ClockSkew { get; set; }
}