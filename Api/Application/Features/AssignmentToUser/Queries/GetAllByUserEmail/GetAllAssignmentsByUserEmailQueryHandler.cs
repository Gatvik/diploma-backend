using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUser.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAllByUserEmail;

public class GetAllAssignmentsByUserEmailQueryHandler : IRequestHandler<GetAllAssignmentsByUserEmailQuery, List<AssignmentToUserDto>>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IMapper _mapper;

    public GetAllAssignmentsByUserEmailQueryHandler(IAssignmentToUserRepository assignmentToUserRepository, IMapper mapper)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _mapper = mapper;
    }
    
    public async Task<List<AssignmentToUserDto>> Handle(GetAllAssignmentsByUserEmailQuery request, CancellationToken cancellationToken)
    {
        var assignments = await _assignmentToUserRepository
            .GetAllByPredicateAsync(predicate: p => p.User.Email == request.Email, 
            includes: [incl => incl.Assignment.Role, incl => incl.AssignmentToUserStatus]);
        
        if (assignments.Count <= 0)
            throw new NotFoundException();
        
        return _mapper.Map<List<AssignmentToUserDto>>(assignments);
    }
}