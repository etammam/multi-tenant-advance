using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using MultiTenant.Catalog.Core.Configurations;

namespace MultiTenant.Catalog.Api.Common.Swagger.Versioned;

public static class VersionedSwaggerExtension
{
    private static string Combining(string xmlFileName)
    {
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
        return xmlPath;
    }

    public static IServiceCollection AddSetupOfVersionedSwagger(this IServiceCollection services,
        IConfiguration configuration
        , string applicationAssemblyName, string swaggerConfigurationSectionName = "swagger")
    {
        var swaggerConfiguration =
            configuration.GetSection(swaggerConfigurationSectionName).Get<SwaggerConfigurations>();
        if (swaggerConfiguration is null)
            throw new Exception("Couldn't load Swagger settings configuration");
        services.AddSingleton(swaggerConfiguration);

        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });
        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'Version 'VVV";
            options.SubstituteApiVersionInUrl = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });

        services.AddSwaggerGen(options =>
        {
            var xmlFilePath = Combining($"{applicationAssemblyName.ToLower()}.xml");
            if (File.Exists(xmlFilePath)) options.IncludeXmlComments(xmlFilePath);
            options.UseInlineDefinitionsForEnums();

            options.CustomSchemaIds(x => x.FullName);
            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = "Jwt Authorization Header Using Bearer Scheme.\n" +
                              "Enter 'Bearer' [space] and then your token in the text input below\n" +
                              "Example: \"Bearer 1231861686016816518a6w1d68as1d86as4d\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = JwtBearerDefaults.AuthenticationScheme
                        },
                        Scheme = "oauth2",
                        Name = JwtBearerDefaults.AuthenticationScheme,
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });

        services.ConfigureOptions<ConfigureSwaggerOptions>();
        return services;
    }

    public static void UseSetupOfVersionedSwagger(this IApplicationBuilder app, IConfiguration configuration,
        string swaggerConfigurationSectionName = "swagger")
    {
        var swaggerConfiguration =
            configuration.GetSection(swaggerConfigurationSectionName).Get<SwaggerConfigurations>();
        if (swaggerConfiguration is null)
            throw new Exception("Couldn't load Swagger settings configuration");

        var provider = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.EnableDeepLinking();
            options.DocumentTitle = swaggerConfiguration.Title;
            foreach (var description in provider?.ApiVersionDescriptions!)
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
        });
    }
}