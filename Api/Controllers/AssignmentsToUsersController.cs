using Api.Application.Attributes;
using Api.Application.Features.AssignmentToUser.Commands.Create;
using Api.Application.Features.AssignmentToUser.Commands.MarkAsCompleted;
using Api.Application.Features.AssignmentToUser.Queries.GetAllByUserId;
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
    [HttpGet("{userId:guid}")]
    [AuthorizeEnums(Roles.Manager)]
    public async Task<ActionResult<Unit>> GetAllByUserId(Guid userId)
    {
        return Ok(await _mediator.Send(new GetAllUserAssignmentsByUserIdQuery {UserId = userId}));
    }
}