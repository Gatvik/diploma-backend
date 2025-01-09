using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using MediatR;

namespace Api.Application.Features.Assignment.Commands.Delete;

public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand, Unit>
{
    private readonly IAssignmentRepository _assignmentRepository;

    public DeleteAssignmentCommandHandler(IAssignmentRepository assignmentRepository)
    {
        _assignmentRepository = assignmentRepository;
    }
    
    public async Task<Unit> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(request.AssignmentId);
        if (assignment is null)
            throw new NotFoundException();

        await _assignmentRepository.DeleteAsync(assignment);
        return Unit.Value;
    }
}