using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Commands.MarkAsCompleted;

public class MarkAssignmentAsCompletedQueryHandler : IRequestHandler<MarkAssignmentAsCompletedQuery, Unit>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public MarkAssignmentAsCompletedQueryHandler(IAssignmentToUserRepository assignmentToUserRepository, IUserService userService, IMapper mapper)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(MarkAssignmentAsCompletedQuery request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var assignment = await _assignmentToUserRepository.GetByPredicateAsync(
            a => a.UserId.ToString() == userId && a.Id == request.AssignmentToUserId);
        if (assignment is null)
            throw new NotFoundException();

        assignment.IsCompleted = true;
        await _assignmentToUserRepository.UpdateAsync(assignment);
        return Unit.Value;
    }
}