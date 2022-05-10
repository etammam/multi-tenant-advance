using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenant.Catalog.Api.Common;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Authorize]
public class BaseController : ControllerBase
{
    private ISender? _mediator;
    protected ISender? Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
}