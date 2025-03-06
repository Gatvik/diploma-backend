using MediatR;

namespace Api.Application.Features.AssignmentToUser.Commands.ChangeStatus;

public class ChangeAssignmentToUserCommand : IRequest<Unit>
{
    public Guid AssignmentToUserId { get; set; }
    public Guid NewStatusId { get; set; }
}