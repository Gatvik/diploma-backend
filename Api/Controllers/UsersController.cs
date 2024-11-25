using Api.Application.Features.User.Commands.ChangePassword;
using Api.Application.Features.User.Commands.ConfirmEmail;
using Api.Application.Features.User.Commands.ConfirmPasswordRecovery;
using Api.Application.Features.User.Commands.RecoverPassword;
using Api.Application.Features.User.Queries.GetSelf;
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
    [HttpGet]
    public async Task<ActionResult> GetSelf()
    {
        return Ok(await _mediator.Send(new GetSelfQuery()));
    }
}