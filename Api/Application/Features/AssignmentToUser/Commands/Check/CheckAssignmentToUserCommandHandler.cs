using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Commands.Check;

public class CheckAssignmentToUserCommandHandler : IRequestHandler<CheckAssignmentToUserCommand, Unit>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IAssignmentToUserStatusRepository _assignmentToUserStatusRepository;

    public CheckAssignmentToUserCommandHandler(IAssignmentToUserRepository assignmentToUserRepository, IAssignmentToUserStatusRepository assignmentToUserStatusRepository)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _assignmentToUserStatusRepository = assignmentToUserStatusRepository;
    }
    
    public async Task<Unit> Handle(CheckAssignmentToUserCommand request, CancellationToken cancellationToken)
    {
        var assignment = await _assignmentToUserRepository.GetSingleByPredicateAsync(
            a => a.Id == request.AssignmentToUserId, atu => atu.AssignmentToUserStatus);
        
        var validator = new CheckAssignmentToUserCommandValidator(_assignmentToUserStatusRepository, assignment);
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);

        assignment!.AssignmentToUserStatusId = request.NewStatusId;
        await _assignmentToUserRepository.UpdateAsync(assignment);
        return Unit.Value;
    }
}