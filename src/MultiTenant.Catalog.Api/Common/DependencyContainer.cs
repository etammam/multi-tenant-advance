using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MultiTenant.Catalog.Api.Common.Middleware;
using MultiTenant.Catalog.Core;
using MultiTenant.Catalog.Core.Configurations;
using MultiTenant.Catalog.Infrastructure;
using MultiTenant.Catalog.Infrastructure.Persistence;
using MultiTenant.Catalog.Infrastructure.Persistence.Configurations;
using Serilog;
using Serilog.Exceptions;
using WatchDog;
using WatchDog.src.Enums;

namespace MultiTenant.Catalog.Api.Common;

internal static class DependencyContainer
{
    internal static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger =>
        (context, configuration) =>
        {
            var env = context.HostingEnvironment;

            configuration
                .Enrich.FromLogContext()
                .Enrich.WithProperty("ApplicationName", env.ApplicationName)
                .Enrich.WithProperty("EnvironmentName", env.EnvironmentName)
                .Enrich.WithExceptionDetails()
                .WriteTo.Elasticsearch(
                    ElasticSinkConfiguration.ConfigureElasticSink(context.Configuration, env.EnvironmentName))
                .WriteTo.Console();
        };

    internal static IServiceCollection AddCatalog(this IServiceCollection services,
        IConfiguration configuration)
    {
        var catalogConnection = new CatalogConnectionConfiguration();
        configuration.Bind("Connections:Context", catalogConnection);
        services.Configure<CatalogConnectionConfiguration>(configuration.GetSection("Connections:Context"));

        services.AddCatalogCore();
        services.AddCatalogInfrastructure(configuration);
        services.AddCatalogContext(options =>
        {
            options.Provider = catalogConnection.Provider;
            options.ConnectionString = catalogConnection.ConnectionString;
        });

        return services;
    }

    internal static IServiceCollection AddWatchInterceptor(this IServiceCollection services)
    {
        services.AddWatchDogServices(options =>
        {
            options.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Monthly;
            options.IsAutoClear = false;
        });
        return services;
    }

    internal static IApplicationBuilder UseWatchInterceptor(this IApplicationBuilder app)
    {
        app.UseWatchDogExceptionLogger();
        app.UseWatchDog(options =>
        {
            options.WatchPageUsername = "admin";
            options.WatchPagePassword = "ok";
        });
        return app;
    }

    internal static IServiceCollection AddSetupOfAuthentication(this IServiceCollection services,
        IConfiguration configuration,
        string jwtConfigurationsSectionName = "JwtConfigurations")
    {
        var jwtSettingsConfiguration = configuration.GetSection(jwtConfigurationsSectionName);
        services.Configure<JwtConfigurations>(jwtSettingsConfiguration);
        var jwtSettings = jwtSettingsConfiguration.Get<JwtConfigurations>();
        services.AddSingleton(jwtSettings);

        if (jwtSettings is null)
            throw new Exception("Couldn't load jwt settings configuration");

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = true;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { jwtSettings.Issuer },
                ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidAudience = jwtSettings.Audience,
                ValidateAudience = jwtSettings.ValidateAudience,
                ValidateLifetime = jwtSettings.ValidateLifeTime,
                ClockSkew = TimeSpan.FromMinutes(1)
            };
        });
        services.AddAuthorization();
        return services;
    }


    public static IApplicationBuilder UseSetupOfAutomaticMigrations(this IApplicationBuilder app,
        IConfiguration configuration,
        string applicationSettingsSectionName = "settings")
    {
        var applicationSettings = configuration.GetSection(applicationSettingsSectionName)
            .Get<ApplicationSettingConfiguration>();

        if (applicationSettings is null)
            throw new Exception("Couldn't load Application settings configuration");

        if (!applicationSettings.EnableAutomaticMigrations)
            return app;

        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
        var database = scope?.ServiceProvider.GetRequiredService<ICatalogContext>().Database;
        database?.EnsureCreated();
        database?.Migrate();
        return app;
    }

    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddTransient<ExceptionMiddleware>();
        return services;
    }
}