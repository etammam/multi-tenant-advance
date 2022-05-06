using MultiTenant.Catalog.Api.Common;
using MultiTenant.Catalog.Api.Common.Middleware;
using MultiTenant.Catalog.Api.Common.Swagger.Versioned;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(DependencyContainer.ConfigureLogger);
builder.Configuration.AddJsonFile("appsettings.local.json", true, true);

builder.Services.AddControllers();
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
app.UseSetupOfVersionedSwagger(builder.Configuration);
app.UseMiddleware<ExceptionMiddleware>();
app.UseSetupOfAutomaticMigrations(builder.Configuration);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseWatchInterceptor();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();