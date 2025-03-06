using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUser.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAllOwnByDate;

public class GetAllOwnAssignmentsByDateQueryHandler : IRequestHandler<GetAllOwnAssignmentsByDateQuery, List<AssignmentToUserDto>>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetAllOwnAssignmentsByDateQueryHandler(IAssignmentToUserRepository assignmentToUserRepository, IMapper mapper,
        IUserService userService)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _mapper = mapper;
        _userService = userService;
    }
    
    public async Task<List<AssignmentToUserDto>> Handle(GetAllOwnAssignmentsByDateQuery request, CancellationToken cancellationToken)
    {
        var assignments = await _assignmentToUserRepository
            .GetAllByPredicateAsync(predicate: p => 
                    p.User.Id == Guid.Parse(_userService.UserId) 
                    && p.StartTime.Month == request.Month 
                    && p.StartTime.Year == request.Year,
                includes: [incl => incl.Assignment, incl => incl.AssignmentToUserStatus]);

        if (assignments.Count == 0)
            throw new NotFoundException("No assignments");
        
        return _mapper.Map<List<AssignmentToUserDto>>(assignments);
    }
}