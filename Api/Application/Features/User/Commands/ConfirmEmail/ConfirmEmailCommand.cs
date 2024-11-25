using MediatR;

namespace Api.Application.Features.User.Commands.ConfirmEmail;

public class ConfirmEmailCommand : IRequest<Unit>
{
    public string ValidationCode { get; set; }
}