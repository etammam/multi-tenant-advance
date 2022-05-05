using System.Text.Json.Serialization;

namespace MultiTenant.Catalog.Core.Contracts;

public class AuthenticationResult
{
    public AuthenticationResult(string accessToken, RefreshToken refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }

    [JsonPropertyName("accessToken")] public string AccessToken { get; set; }

    [JsonPropertyName("refreshToken")] public RefreshToken RefreshToken { get; set; }
}