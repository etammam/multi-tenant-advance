using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MultiTenant.Catalog.Core.Configurations;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MultiTenant.Catalog.Api.Common.Swagger.Versioned;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    private readonly SwaggerConfigurations _swaggerConfigurations;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, SwaggerConfigurations swaggerConfigurations)
    {
        _provider = provider;
        _swaggerConfigurations = swaggerConfigurations;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, _swaggerConfigurations));
    }

    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }

    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description,
        SwaggerConfigurations swaggerConfiguration)
    {
        var info = new OpenApiInfo
        {
            Title = swaggerConfiguration.Title,
            Description = swaggerConfiguration.Description,
            Version = description.ApiVersion.ToString(),
            Contact = new OpenApiContact
            {
                Name = swaggerConfiguration.Contact.Name,
                Email = swaggerConfiguration.Contact.Email
            }
        };

        if (description.IsDeprecated) info.Description += " This API version has been deprecated.";

        return info;
    }
}