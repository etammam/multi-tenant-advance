using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MultiTenant.Catalog.Api.Common;
using MultiTenant.Catalog.Api.Common.Middleware;
using MultiTenant.Catalog.Api.Common.Swagger.Versioned;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(DependencyContainer.ConfigureLogger);
builder.Configuration.AddJsonFile("appsettings.local.json", true, true);

builder.Services.AddControllers(options =>
{
    var requireAuthenticatedUserPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .Build();
    options.Filters.Add(new AuthorizeFilter(requireAuthenticatedUserPolicy));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSetupOfVersionedSwagger(builder.Configuration,
    typeof(Program).Assembly.GetName()
        .Name ??
    nameof(Assemblage));
builder.Services.AddCustomServices();
builder.Services.AddCatalog(builder.Configuration);
builder.Services.AddWatchInterceptor();
builder.Services.AddSetupOfAuthentication(builder.Configuration);


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
app.UseSetupOfVersionedSwagger(builder.Configuration);
app.UseSetupOfAutomaticMigrations(builder.Configuration);
app.UseWatchInterceptor();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();