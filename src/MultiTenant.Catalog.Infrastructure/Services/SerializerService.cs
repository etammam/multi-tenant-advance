using System.Text.Json;
using System.Text.Json.Serialization;
using MultiTenant.Catalog.Core.Common;

namespace MultiTenant.Catalog.Infrastructure.Services;

public class SerializerService : ISerializerService
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true,
        Converters =
        {
            new JsonStringEnumConverter()
        }
    };

    public T Deserialize<T>(string source)
    {
        return JsonSerializer.Deserialize<T>(source, Options)!;
    }

    public string Serialize<T>(T model)
    {
        return JsonSerializer.Serialize(model, Options);
    }
}