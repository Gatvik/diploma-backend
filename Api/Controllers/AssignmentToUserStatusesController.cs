using Api.Application.Attributes;
using Api.Application.Features.AssignmentToUser.Queries.GetById;
using Api.Application.Features.AssignmentToUserStatus.Queries.GetAll;
using Api.Application.Features.AssignmentToUserStatus.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/assignmentToUserStatuses")]
public class AssignmentToUserStatusesController : ControllerBase
{
    private readonly IMediator _mediator;

    public AssignmentToUserStatusesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Unit>> Get([FromQuery] Guid? statusId)
    {
        if (statusId is not null)
            return Ok(await _mediator.Send(new GetAssignmentToUserStatusByIdQuery { Id = statusId.Value }));

        return Ok(await _mediator.Send(new GetAllAssignmentToUserStatusesQuery()));
    }
}