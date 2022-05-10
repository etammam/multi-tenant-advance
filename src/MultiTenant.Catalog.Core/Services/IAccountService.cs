using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Core.Services;

public interface IAccountService
{
    Task<AuthenticationResult> LoginAsync(string email, string password);
}