using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiTenant.Catalog.Api.Common;
using MultiTenant.Catalog.Core.Callers.Business.Commands;
using MultiTenant.Catalog.Core.Callers.Business.Queries;
using MultiTenant.Catalog.Core.Contracts;
using MultiTenant.Catalog.Domain.Constants;

namespace MultiTenant.Catalog.Api.Controllers;

public class BusinessController : BaseController
{
    [Authorize(Roles = RoleNames.Business.CanViewAll)]
    [HttpGet(ApiRoutes.Business.GetList)]
    public async Task<ActionResult<List<BusinessContract>>> GetBusinessList()
    {
        return await Mediator?.Send(new GetBusinessListQuery())!;
    }


    [HttpGet(ApiRoutes.Business.Get)]
    public async Task<ActionResult<BusinessContract>> GetBusiness([FromQuery] Guid id)
    {
        return await Mediator?.Send(new GetBusinessQuery(id))!;
    }

    [HttpPost(ApiRoutes.Business.Post)]
    public async Task<ActionResult<BusinessContract>> Post(CreateBusinessCommand model)
    {
        return await Mediator?.Send(model)!;
    }


    [HttpPut(ApiRoutes.Business.Put)]
    public async Task<ActionResult<BusinessContract>> Put(UpdateBusinessCommand model)
    {
        return await Mediator?.Send(model)!;
    }

    [HttpDelete(ApiRoutes.Business.Delete)]
    public async Task<ActionResult<bool>> Delete([FromQuery] Guid id)
    {
        return await Mediator?.Send(new DeleteBusinessCommand(id))!;
    }
}