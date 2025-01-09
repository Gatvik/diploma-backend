using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.Assignment.Commands.Update;

public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, Unit>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly RoleManager<Role> _roleManager;

    public UpdateAssignmentCommandHandler(IAssignmentRepository assignmentRepository, RoleManager<Role> roleManager)
    {
        _assignmentRepository = assignmentRepository;
        _roleManager = roleManager;
    }
    
    public async Task<Unit> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(request.Id);
        if (assignment is null)
            throw new NotFoundException();

        var validator = new UpdateAssignmentCommandValidator(_assignmentRepository, _roleManager);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);

        assignment.Name = request.Name;
        assignment.RoleId = request.RoleId;

        await _assignmentRepository.UpdateAsync(assignment);
        return Unit.Value;
    }
}