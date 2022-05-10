using MediatR;
using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Core.Services;

namespace MultiTenant.Catalog.Core.Callers.Account.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResult>
{
    private readonly IAccountService _accountService;

    public LoginCommandHandler(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public async Task<AuthenticationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await _accountService.LoginAsync(request.Email, request.Password);
        return result;
    }
}