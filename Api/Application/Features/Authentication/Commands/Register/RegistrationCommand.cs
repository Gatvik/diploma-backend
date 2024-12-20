﻿using Api.Data.Models;
using MediatR;

namespace Api.Application.Features.Authentication.Commands.Register;

public class RegistrationCommand : IRequest<RegistrationResponse>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
    public string Sex { get; set; }
    public string Role { get; set; }
}