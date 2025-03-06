using Api.Application.Contracts.Persistence;
using Api.Data.Models;
using FluentValidation;

namespace Api.Application.Features.AssignmentToUser.Commands.Check;

public class CheckAssignmentToUserCommandValidator : AbstractValidator<CheckAssignmentToUserCommand>
{
    private readonly Domain.AssignmentToUser? _assignmentToUser;
    private readonly IAssignmentToUserStatusRepository _assignmentToUserStatusRepository;

    public CheckAssignmentToUserCommandValidator(IAssignmentToUserStatusRepository assignmentToUserStatusRepository,
        Domain.AssignmentToUser? assignmentToUser)
    {
        _assignmentToUserStatusRepository = assignmentToUserStatusRepository;
        _assignmentToUser = assignmentToUser;
        
        RuleFor(atus => atus.NewStatusId).CustomAsync(CorrectStatus);
    }
    
    private async Task<bool> CorrectStatus(Guid statusId, ValidationContext<CheckAssignmentToUserCommand> context, CancellationToken ct)
    {
        var assignment = _assignmentToUser;
        if (assignment is null)
        {
            context.AddFailure("AssignmentToUserId", "Not found");
            return false;
        }

        var currentStatusAsEnum = Enum.Parse<AssignmentToUserStatuses>(assignment.AssignmentToUserStatus.Name.Replace(" ", ""));
        var newStatus = await _assignmentToUserStatusRepository.GetByIdAsync(statusId);
        if (newStatus is null)
        {
            context.AddFailure( "Status is not found");
            return false;
        }
        
        var newStatusAsEnum = Enum.Parse<AssignmentToUserStatuses>(newStatus.Name.Replace(" ", ""));
        switch (newStatusAsEnum)
        {
            case AssignmentToUserStatuses.Rejected or AssignmentToUserStatuses.Approved:
                if (currentStatusAsEnum is not AssignmentToUserStatuses.Completed)
                {
                    context.AddFailure("\"Rejected\" or \"Approved\" can be set only if previous status was \"Completed\"");
                    return false;
                }
                break;
            default:
                context.AddFailure("You have not permissions to set this status");
                return false;
        }

        return true;
    }
}