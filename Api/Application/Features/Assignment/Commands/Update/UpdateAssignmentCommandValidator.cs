using Api.Application.Contracts.Persistence;
using Api.Data.Models;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.Assignment.Commands.Update;

public class UpdateAssignmentCommandValidator : AbstractValidator<UpdateAssignmentCommand>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly RoleManager<Role> _roleManager;

    public UpdateAssignmentCommandValidator(IAssignmentRepository assignmentRepository, RoleManager<Role> roleManager)
    {
        _assignmentRepository = assignmentRepository;
        _roleManager = roleManager;

        RuleFor(a => a.Name)
            .MustAsync(IsUnique).WithMessage("Name must be unique");

        RuleFor(a => a.RoleId)
            .MustAsync(IsExist).WithMessage("Only Technician and Housemaid can have assignments");
    }
    
    private async Task<bool> IsExist(Guid roleId, CancellationToken ct)
    {
        var role = await _roleManager.FindByIdAsync(roleId.ToString());

        return role is not null && 
               (role.Name == Enum.GetName(Roles.Technician) || role.Name == Enum.GetName(Roles.Housemaid));
    }

    private async Task<bool> IsUnique(UpdateAssignmentCommand command, string name, CancellationToken ct)
    {
        var assignment = await _assignmentRepository.GetSingleByPredicateAsync(i => i.Name == name);
        if (assignment is not null)
        {
            var itemById = await _assignmentRepository.GetByIdAsync(command.Id);

            return assignment.Id == itemById!.Id;
        }

        return assignment is null;
    }
}