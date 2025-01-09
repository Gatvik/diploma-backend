using MediatR;

namespace Api.Application.Features.Assignment.Commands.Delete;

public class DeleteAssignmentCommand : IRequest<Unit>
{
    public Guid AssignmentId { get; set; }
}