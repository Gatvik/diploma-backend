using MediatR;

namespace Api.Application.Features.AssignmentToUser.Commands.Check;

public class CheckAssignmentToUserCommand : IRequest<Unit>
{
    public Guid AssignmentToUserId { get; set; }
    public Guid NewStatusId { get; set; }
}