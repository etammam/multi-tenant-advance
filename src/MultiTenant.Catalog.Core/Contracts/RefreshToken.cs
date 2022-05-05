using System.Text.Json.Serialization;

namespace MultiTenant.Catalog.Core.Contracts;

public class RefreshToken
{
    public RefreshToken(string userName, string tokenString, DateTime expireAt)
    {
        UserName = userName;
        TokenString = tokenString;
        ExpireAt = expireAt;
    }

    [JsonPropertyName("username")] public string UserName { get; set; }

    [JsonPropertyName("tokenString")] public string TokenString { get; set; }

    [JsonPropertyName("expireAt")] public DateTime ExpireAt { get; set; }
}