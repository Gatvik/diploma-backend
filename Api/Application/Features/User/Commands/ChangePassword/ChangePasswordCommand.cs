using MediatR;

namespace Api.Application.Features.User.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<Unit>
{
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}