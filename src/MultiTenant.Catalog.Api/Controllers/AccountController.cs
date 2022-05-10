using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Catalog.Api.Common;
using MultiTenant.Catalog.Core.Callers.Account.Commands;
using MultiTenant.Catalog.Core.Contracts;

namespace MultiTenant.Catalog.Api.Controllers;

public class AccountController : BaseController
{
    [AllowAnonymous]
    [HttpPost(ApiRoutes.Account.Login)]
    public async Task<ActionResult<AuthenticationResult>> Login(LoginCommand model)
    {
        return Ok(await Mediator?.Send(model)!);
    }
}