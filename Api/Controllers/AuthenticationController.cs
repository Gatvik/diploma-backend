﻿using Api.Application.Attributes;
using Api.Application.Features.Authentication.Commands.ChangeEmail;
using Api.Application.Features.Authentication.Commands.ChangePassword;
using Api.Application.Features.Authentication.Commands.ConfirmEmail;
using Api.Application.Features.Authentication.Commands.Login;
using Api.Application.Features.Authentication.Commands.Register;
using Api.Application.Features.Authentication.Commands.ValidateToken;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [AuthorizeEnums(Roles.Administrator)]
    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost("validateToken")]
    public async Task<ActionResult<ValidateTokenResponse>> ValidateToken(ValidateTokenCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [Authorize]
    [HttpPost("changePassword")]
    public async Task<ActionResult<Unit>> ChangePassword(ChangePasswordCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [Authorize]
    [HttpPost("confirmEmail")]
    public async Task<ActionResult<Unit>> ConfirmEmail(ConfirmEmailCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    
}