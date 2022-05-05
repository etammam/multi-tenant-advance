using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Catalog.Api.Common;

namespace MultiTenant.Catalog.Api.Controllers;

public class FoobarController : BaseController
{
    [AllowAnonymous]
    [HttpGet(ApiRoutes.Foobar.Princess)]
    public ActionResult<string> IsMarioPrincessHere()
    {
        return Ok("Hello Mario, your princess is in another castle");
    }
}