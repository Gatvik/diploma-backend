using Api.Application.Contracts.Persistence;
using Api.Data.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.AssignmentToUser.Create;

public class CreateAssignmentToUserCommandValidator : AbstractValidator<CreateAssignmentToUserCommand>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;

    public CreateAssignmentToUserCommandValidator(UserManager<AppUser> userManager, IAssignmentRepository assignmentRepository,
        IAssignmentToUserRepository assignmentToUserRepository)
    {
        _userManager = userManager;
        _assignmentRepository = assignmentRepository;
        _assignmentToUserRepository = assignmentToUserRepository;
        RuleFor(atu => atu.Details)
            .NotEmpty().WithMessage("Can't be empty")
            .MaximumLength(500).WithMessage("Maximum length is 500");

        RuleFor(atu => atu.UserId)
            .MustAsync(UserMustExists).WithMessage("Not exist");
        
        RuleFor(atu => atu.AssignmentId)
            .MustAsync(AssignmentMustExists).WithMessage("Not exist");

        RuleFor(atu => atu.StartTime)
            .Must(MustBeUtc).WithMessage("Must be in UTC format");
        
        RuleFor(atu => atu.EndTime)
            .Must(MustBeUtc).WithMessage("Must be in UTC format");
        
        RuleFor(atu => atu)
            .CustomAsync(async (atu, context, cancellationToken) =>
            {
                bool isTimeAvailable = await IsTimeAvailableForUser(atu.UserId, atu.StartTime, atu.EndTime);
                if (!isTimeAvailable)
                {
                    context.AddFailure("The time to complete this assignment overlaps with another assignment");
                }
            });
    }
    
    private async Task<bool> IsTimeAvailableForUser(Guid userId, DateTime startTime, DateTime endTime)
    {
        var assignments = await _assignmentToUserRepository.GetAllByUserId(userId);
        return !assignments.Any(a => startTime < a.EndTime && endTime > a.StartTime);
    }

    private async Task<bool> AssignmentMustExists(Guid assignmentId, CancellationToken arg2)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(assignmentId);
        return assignment is not null;
    }

    private async Task<bool> UserMustExists(Guid userId, CancellationToken arg2)
    {
        var appUser = await _userManager.FindByIdAsync(userId.ToString());
        return appUser is not null;
    }

    private bool MustBeUtc(DateTime dateTime)
    {
        return dateTime.Kind == DateTimeKind.Utc;
    }
}