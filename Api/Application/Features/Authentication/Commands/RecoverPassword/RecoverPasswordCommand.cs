using MediatR;

namespace Api.Application.Features.Authentication.Commands.RecoverPassword;

public class RecoverPasswordCommand : IRequest<Unit>
{
    public string Email { get; set; }
}