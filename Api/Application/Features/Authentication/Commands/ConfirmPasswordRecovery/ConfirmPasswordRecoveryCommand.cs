using MediatR;

namespace Api.Application.Features.Authentication.Commands.ConfirmPasswordRecovery;

public class ConfirmPasswordRecoveryCommand : IRequest<Unit>
{
    public string Email { get; set; }
    public string Code { get; set; }
    public string NewPassword { get; set; }
}