namespace MultiTenant.Catalog.Core.Configurations;

public class ElasticConfiguration
{
    public bool Enable { get; set; }
    public string NodeUrl { get; set; }

    public bool UseAuthentication { get; set; } = false;

    public string Username { get; set; }

    public string Password { get; set; }

    public string FormatterName { get; set; }
}