using MultiTenant.Catalog.Core.Configurations;
using Serilog.Sinks.Elasticsearch;

namespace MultiTenant.Catalog.Api.Common;

internal static class ElasticSinkConfiguration
{
    internal static ElasticsearchSinkOptions ConfigureElasticSink(IConfiguration configuration,
        string environment,
        string elasticLoggingSinkSectionName = "elasticSink")
    {
        var elasticLoggingSinkConfiguration = configuration.GetSection(elasticLoggingSinkSectionName);
        var elasticLoggingSinkSettings = elasticLoggingSinkConfiguration.Get<ElasticConfiguration>();
        if (elasticLoggingSinkSettings is null)
            throw new Exception("Couldn't load Elastic Logging Sink Settings configuration");

        if (elasticLoggingSinkSettings.Enable)
        {
            if (elasticLoggingSinkSettings.UseAuthentication)
                return new ElasticsearchSinkOptions(new Uri(elasticLoggingSinkSettings.NodeUrl))
                {
                    ModifyConnectionSettings = connection =>
                        connection.BasicAuthentication(elasticLoggingSinkSettings.Username,
                            elasticLoggingSinkSettings.Password),
                    AutoRegisterTemplate = true,
                    IndexFormat =
                        $"{elasticLoggingSinkSettings.FormatterName?.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
                };
            return new ElasticsearchSinkOptions(new Uri(elasticLoggingSinkSettings.NodeUrl))
            {
                AutoRegisterTemplate = true,
                IndexFormat =
                    $"{elasticLoggingSinkSettings.FormatterName?.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
            };
        }

        return new ElasticsearchSinkOptions();
    }
}