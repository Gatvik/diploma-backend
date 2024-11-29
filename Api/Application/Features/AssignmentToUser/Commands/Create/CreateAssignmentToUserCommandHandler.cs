using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Data.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.AssignmentToUser.Commands.Create;

public class CreateAssignmentToUserCommandHandler : IRequestHandler<CreateAssignmentToUserCommand, Unit>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<Data.Models.User> _userManager;

    public CreateAssignmentToUserCommandHandler(IAssignmentToUserRepository assignmentToUserRepository, 
        IAssignmentRepository assignmentRepository, IMapper mapper, UserManager<Data.Models.User> userManager)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
        _userManager = userManager;
    }
    
    public async Task<Unit> Handle(CreateAssignmentToUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateAssignmentToUserCommandValidator(_userManager, _assignmentRepository, _assignmentToUserRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);

        var assignmentToUser = _mapper.Map<Domain.AssignmentToUser>(request);
        await _assignmentToUserRepository.CreateAsync(assignmentToUser);
        
        return Unit.Value;
    }
}