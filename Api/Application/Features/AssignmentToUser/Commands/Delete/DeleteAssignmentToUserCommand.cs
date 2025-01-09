using MediatR;

namespace Api.Application.Features.AssignmentToUser.Commands.Delete;

public class DeleteAssignmentToUserCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}