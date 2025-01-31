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
    /// <para>When "email" in query is provided, than returns all assignments to users found by user's email</para>
    /// <para>When not, then PAGINATION DATA must be provided. Returns all paginated assignments to users</para>
    /// <para>Default page size - 20, default page number - 1</para>
    /// </remarks>
    [HttpGet]
    [AuthorizeEnums(Roles.Manager)]
    public async Task<ActionResult<Unit>> GetAll([FromQuery] string? email, 
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
    {
        if (email is not null)
            return Ok(await _mediator.Send(new GetAllAssignmentsByUserEmailQuery {Email = email}));
        
        return Ok(await _mediator.Send(new GetAllAssignmentsToUserQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        }));
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