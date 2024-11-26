using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUser.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAllByUserId;

public class GetAllUserAssignmentsByUserIdQueryHandler : IRequestHandler<GetAllUserAssignmentsByUserIdQuery, List<AssignmentToUserDto>>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IMapper _mapper;

    public GetAllUserAssignmentsByUserIdQueryHandler(IAssignmentToUserRepository assignmentToUserRepository, IMapper mapper)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _mapper = mapper;
    }
    
    public async Task<List<AssignmentToUserDto>> Handle(GetAllUserAssignmentsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var assignments = await _assignmentToUserRepository.GetAllByPredicateAsync(p => p.UserId == request.UserId, 
            incl => incl.Assignment.Role, incl => incl.User);
        if (assignments.Count <= 0)
            throw new NotFoundException();
        
        return _mapper.Map<List<AssignmentToUserDto>>(assignments);
    }
}