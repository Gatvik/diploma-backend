using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Commands.Delete;

public class DeleteAssignmentToUserCommandHandler : IRequestHandler<DeleteAssignmentToUserCommand, Unit>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;

    public DeleteAssignmentToUserCommandHandler(IAssignmentToUserRepository assignmentToUserRepository)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
    }
    
    public async Task<Unit> Handle(DeleteAssignmentToUserCommand request, CancellationToken cancellationToken)
    {
        var assignment = await _assignmentToUserRepository.GetByIdAsync(request.Id, includes: atu => atu.AssignmentToUserStatus);
        if (assignment is null)
            throw new NotFoundException("Assignment not found");

        if (assignment.AssignmentToUserStatus.Name is "Approved" or "Rejected")
            throw new BadRequestException("Approved or rejected assignment can not be deleted");

        await _assignmentToUserRepository.DeleteAsync(assignment);

        return Unit.Value;
    }
}