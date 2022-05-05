using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Catalog.Core.Common;
using MultiTenant.Catalog.Core.Services;
using MultiTenant.Catalog.Infrastructure.Common.Pagination;
using MultiTenant.Catalog.Infrastructure.Common.Repositories;
using MultiTenant.Catalog.Infrastructure.Common.Unit;
using MultiTenant.Catalog.Infrastructure.Services;

namespace MultiTenant.Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        var servicesProvider = services.BuildServiceProvider();
        var accessor = servicesProvider.GetRequiredService<IHttpContextAccessor>();
        PaginationHelper.AddHttpContextAccessor(accessor);

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

        services.RegisterServices();
        services.RegisterConfigurations(configuration);
        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        //Generic
        services.AddSingleton<ITokenService, TokenService>();
        services.AddScoped<ISerializerService, SerializerService>();
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        //Business
        services.AddScoped<IBusinessService, BusinessService>();
        services.AddScoped<IPlanService, PlanService>();
        services.AddScoped<IResourceService, ResourceService>();
        services.AddScoped<ITenantService, TenantService>();

        return services;
    }

    private static IServiceCollection RegisterConfigurations(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}