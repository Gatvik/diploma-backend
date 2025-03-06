using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Persistence;
using Api.Data.Models;
using Api.Domain;
using FluentValidation;

namespace Api.Application.Features.AssignmentToUser.Commands.ChangeStatus;

public class ChangeAssignmentToUserCommandValidator : AbstractValidator<ChangeAssignmentToUserCommand>
{
    private readonly Domain.AssignmentToUser? _assignmentToUser;
    private readonly IAssignmentToUserStatusRepository _assignmentToUserStatusRepository;

    public ChangeAssignmentToUserCommandValidator(IAssignmentToUserStatusRepository assignmentToUserStatusRepository, Domain.AssignmentToUser? assignmentToUser)
    {
        _assignmentToUserStatusRepository = assignmentToUserStatusRepository;
        _assignmentToUser = assignmentToUser;

        RuleFor(atus => atus.NewStatusId).CustomAsync(CorrectStatus);
    }

    private async Task<bool> CorrectStatus(Guid statusId, ValidationContext<ChangeAssignmentToUserCommand> context, CancellationToken ct)
    {
        var assignment = _assignmentToUser;
        if (assignment is null)
        {
            context.AddFailure("AssignmentToUserId", "Not found or don't belong to logged user");
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
            case AssignmentToUserStatuses.InProgress:
                if (currentStatusAsEnum is not AssignmentToUserStatuses.NotAccepted)
                {
                    context.AddFailure("\"In Progress\" can be set only if previous status was \"Not Accepted\"");
                    return false;
                }

                break;
            case AssignmentToUserStatuses.Completed:
                if (currentStatusAsEnum is not AssignmentToUserStatuses.InProgress)
                {
                    context.AddFailure("\"Completed\" can be set only if previous status was \"In Progress\"");
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