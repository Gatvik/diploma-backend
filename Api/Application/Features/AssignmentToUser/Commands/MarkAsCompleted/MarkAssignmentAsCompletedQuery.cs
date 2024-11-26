using MediatR;

namespace Api.Application.Features.AssignmentToUser.Commands.MarkAsCompleted;

public class MarkAssignmentAsCompletedQuery : IRequest<Unit>
{
    public Guid AssignmentToUserId { get; set; }
}