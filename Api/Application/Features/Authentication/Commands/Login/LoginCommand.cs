using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Api.Application.Features.Authentication.Commands.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}