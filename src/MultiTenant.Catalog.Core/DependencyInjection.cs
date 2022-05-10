using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MultiTenant.Catalog.Core.Behaviors;
using System.Diagnostics;
using System.Reflection;

namespace MultiTenant.Catalog.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCatalogCore(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        var serviceProvider = services.BuildServiceProvider();
        var logger = serviceProvider.GetService<ILogger<AssemblyPointer>>();
        if (logger != null) services.AddSingleton(typeof(ILogger), logger);
        services.AddTransient<Stopwatch>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}