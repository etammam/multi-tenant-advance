using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MultiTenant.Catalog.Api.Common;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class BaseController : ControllerBase
{
    private ISender? _mediator;
    protected ISender? Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
}