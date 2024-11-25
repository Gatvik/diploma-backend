using MediatR;

namespace Api.Application.Features.User.Commands.RecoverPassword;

public class RecoverPasswordCommand : IRequest<Unit>
{
    public string Email { get; set; }
}