using Api.Application.Features.AppRole.Queries.GetRoleByName;
using Api.Application.Features.AppRole.Queries.GetRoles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/roles")]
[Authorize]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <remarks>
    /// Allowed roles: any (except non-authorized)
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<string[]>> GetAll([FromQuery] string? roleName)
    {
        if (roleName is null)
            return Ok(await _mediator.Send(new GetRolesQuery()));
        
        return Ok(await _mediator.Send(new GetRoleByNameQuery { Name = roleName}));
    }
}