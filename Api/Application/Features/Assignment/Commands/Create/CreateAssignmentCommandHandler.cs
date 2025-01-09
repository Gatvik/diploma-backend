using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Data.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.Assignment.Commands.CreateAssignmentCommand;

public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, Unit>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public CreateAssignmentCommandHandler(IAssignmentRepository assignmentRepository, RoleManager<Role> roleManager, IMapper mapper)
    {
        _assignmentRepository = assignmentRepository;
        _roleManager = roleManager;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(Commands.CreateAssignmentCommand.CreateAssignmentCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateAssignmentCommandValidator(_assignmentRepository, _roleManager);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);

        var assignment = _mapper.Map<Domain.Assignment>(request);
        await _assignmentRepository.CreateAsync(assignment);

        return Unit.Value;
    }
}