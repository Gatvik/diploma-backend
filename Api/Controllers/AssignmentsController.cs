using Api.Application.Attributes;
using Api.Application.Features.Assignment.Commands;
using Api.Application.Features.Assignment.Commands.CreateAssignmentCommand;
using Api.Application.Features.Assignment.Commands.Delete;
using Api.Application.Features.Assignment.Commands.Update;
using Api.Application.Features.Assignment.Common;
using Api.Application.Features.Assignment.Queries.GetAll;
using Api.Application.Features.Assignment.Queries.GetByRoleId;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/assignments")]
[AuthorizeEnums(Roles.Manager)]
public class AssignmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssignmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <remarks>
    /// Allowed roles: Manager
    /// </remarks>
    [HttpPost]
    public async Task<ActionResult<Unit>> Create(CreateAssignmentCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    /// <remarks>
    /// Allowed roles: Manager
    /// </remarks>
    [HttpDelete]
    public async Task<ActionResult<Unit>> Delete(DeleteAssignmentCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    /// <remarks>
    /// Allowed roles: Manager
    /// </remarks>
    [HttpPut]
    public async Task<ActionResult<Unit>> Update(UpdateAssignmentCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    /// <remarks>
    /// Allowed roles: Manager
    /// <para>PAGINATION DATA can be provided. Returns all (paginated) assignments to users</para>
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<List<AssignmentDto>>> GetAll(int? pageSize, int? pageNumber)
    {
        return Ok(await _mediator.Send(new GetAllAssignmentsQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        }));
    }
    
    [HttpGet("byRole/{roleId:guid}")]
    public async Task<ActionResult<List<AssignmentDto>>> GetAllByRole([FromRoute] Guid roleId, int? pageSize, int? pageNumber)
    {
        return Ok(await _mediator.Send(new GetAssignmentsByRoleIdQuery
        {
            RoleId = roleId,
            PageNumber = pageNumber,
            PageSize = pageSize
        }));
    }
}