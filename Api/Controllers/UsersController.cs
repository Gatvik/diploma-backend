using Api.Application.Attributes;
using Api.Application.Features.User.Commands.ChangePassword;
using Api.Application.Features.User.Commands.ConfirmEmail;
using Api.Application.Features.User.Commands.ConfirmPasswordRecovery;
using Api.Application.Features.User.Commands.RecoverPassword;
using Api.Application.Features.User.Commands.Update;
using Api.Application.Features.User.Queries.GetAll;
using Api.Application.Features.User.Queries.GetById;
using Api.Application.Features.User.Queries.GetSelf;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <remarks>
    /// Allowed roles: Administrator
    /// </remarks>
    [AuthorizeEnums(Roles.Administrator)]
    [HttpPut("update")]
    public async Task<ActionResult<Unit>> ChangePassword(UpdateUserCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    /// <remarks>
    /// Allowed roles: any (except non-authorized)
    /// </remarks>
    [Authorize]
    [HttpPut("changePassword")]
    public async Task<ActionResult<Unit>> ChangePassword(ChangePasswordCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    /// <remarks>
    /// Allowed roles: any (except non-authorized)
    /// </remarks>
    [Authorize]
    [HttpPut("confirmEmail")]
    public async Task<ActionResult<Unit>> ConfirmEmail(ConfirmEmailCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPut("recoverPassword")]
    public async Task<ActionResult<Unit>> RecoverPassword(RecoverPasswordCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPut("confirmPasswordRecovery")]
    public async Task<ActionResult<Unit>> ConfirmPasswordRecover(ConfirmPasswordRecoveryCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    /// <remarks>
    /// <para>Allowed roles: any (except non-authorized)</para>
    /// <para>Gets user information by UID in JWT</para>
    /// </remarks>
    [Authorize]
    [HttpGet("self")]
    public async Task<ActionResult> GetSelf()
    {
        return Ok(await _mediator.Send(new GetSelfQuery()));
    }
    
    /// <remarks>
    /// <para>Allowed roles: Manager, Administrator, InventoryManager</para>
    /// <para>When "id" in query provided, than returns 1 user by id</para>
    /// <para>When not, returns all users</para>
    /// </remarks>
    [AuthorizeEnums(Roles.Manager, Roles.Administrator, Roles.InventoryManager)]
    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] Guid? id)
    {
        if (id is null)
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        
        return Ok(await _mediator.Send(new GetUserByIdQuery {UserId = id.Value}));
    }
}