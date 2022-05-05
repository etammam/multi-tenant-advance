namespace MultiTenant.Catalog.Core.Common;

public interface ISerializerService
{
    string Serialize<T>(T model);
    T Deserialize<T>(string source);
}