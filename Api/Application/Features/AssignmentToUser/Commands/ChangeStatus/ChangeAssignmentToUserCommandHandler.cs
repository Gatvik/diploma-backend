using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Commands.ChangeStatus;

public class ChangeAssignmentToUserCommandHandler : IRequestHandler<ChangeAssignmentToUserCommand, Unit>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IAssignmentToUserStatusRepository _assignmentToUserStatusRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public ChangeAssignmentToUserCommandHandler(IAssignmentToUserRepository assignmentToUserRepository, IAssignmentToUserStatusRepository assignmentToUserStatusRepository, 
        IUserService userService, IMapper mapper)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _assignmentToUserStatusRepository = assignmentToUserStatusRepository;
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(ChangeAssignmentToUserCommand request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var assignment = await _assignmentToUserRepository.GetSingleByPredicateAsync(
            a => a.UserId.ToString() == userId && a.Id == request.AssignmentToUserId, atu => atu.AssignmentToUserStatus);
        
        var validator = new ChangeAssignmentToUserCommandValidator(_assignmentToUserStatusRepository, assignment);
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);

        assignment!.AssignmentToUserStatusId = request.NewStatusId;
        await _assignmentToUserRepository.UpdateAsync(assignment);
        return Unit.Value;
    }
}