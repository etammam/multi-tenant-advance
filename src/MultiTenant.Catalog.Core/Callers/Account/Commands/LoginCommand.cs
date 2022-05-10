using MediatR;
using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Core.Callers.Account.Commands;

public class LoginCommand : IRequest<AuthenticationResult>
{
    public LoginCommand()
    {
    }

    public LoginCommand(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}