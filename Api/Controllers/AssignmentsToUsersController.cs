using Api.Application.Attributes;
using Api.Application.Features.AssignmentToUser.Commands.Create;
using Api.Application.Features.AssignmentToUser.Commands.Delete;
using Api.Application.Features.AssignmentToUser.Commands.MarkAsCompleted;
using Api.Application.Features.AssignmentToUser.Queries.GetAll;
using Api.Application.Features.AssignmentToUser.Queries.GetAllByUserEmail;
using Api.Application.Features.AssignmentToUser.Queries.GetAllOwn;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/assignmentsToUsers")]
public class AssignmentsToUsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssignmentsToUsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <remarks>
    /// Allowed roles: Manager
    /// </remarks>
    [HttpPost]
    [AuthorizeEnums(Roles.Manager)]
    public async Task<ActionResult<Unit>> Create(CreateAssignmentToUserCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    /// <remarks>
    /// Allowed roles: Housemaid, Technician
    /// </remarks>
    [HttpPut("markAsCompleted")]
    [AuthorizeEnums(Roles.Housemaid, Roles.Technician)]
    public async Task<ActionResult<Unit>> MarkAsCompleted(MarkAssignmentAsCompletedQuery request)
    {
        return Ok(await _mediator.Send(request));
    }

    /// <remarks>
    /// Allowed roles: Manager
    /// </remarks>
    [HttpDelete]
    [AuthorizeEnums(Roles.Manager)]
    public async Task<ActionResult<Unit>> Delete(DeleteAssignmentToUserCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    /// <remarks>
    /// Allowed roles: Manager
    /// <para>When "email" in query provided, than returns all assignments to users found by user's email</para>
    /// <para>When not, returns all all assignments to users</para>
    /// </remarks>
    [HttpGet]
    [AuthorizeEnums(Roles.Manager)]
    public async Task<ActionResult<Unit>> GetAll([FromQuery] string? email)
    {
        if (email is null)
            return Ok(await _mediator.Send(new GetAllAssignmentsToUserQuery()));
            
        return Ok(await _mediator.Send(new GetAllAssignmentsByUserEmailQuery {Email = email}));
    }
    
    /// <remarks>
    /// Allowed roles: Technician, Housemaid
    /// <para>By user id in JWT finds all his tasks</para>
    /// </remarks>
    [HttpGet("allOwn")]
    [AuthorizeEnums(Roles.Technician, Roles.Housemaid)]
    public async Task<ActionResult<Unit>> GetAllOwn()
    {
        return Ok(await _mediator.Send(new GetAllOwnAssignmentsQuery()));
    }
}