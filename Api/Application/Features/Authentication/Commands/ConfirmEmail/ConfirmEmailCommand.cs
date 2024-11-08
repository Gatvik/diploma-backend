﻿using MediatR;

namespace Api.Application.Features.Authentication.Commands.ConfirmEmail;

public class ConfirmEmailCommand : IRequest<Unit>
{
    public string ValidationCode { get; set; }
}