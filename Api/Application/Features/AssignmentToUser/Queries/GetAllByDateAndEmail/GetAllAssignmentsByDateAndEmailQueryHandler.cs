using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUser.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAllByDate;

public class GetAllAssignmentsByDateAndEmailQueryHandler : IRequestHandler<GetAllAssignmentsByDateAndEmailQuery, List<AssignmentToUserDto>>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IMapper _mapper;

    public GetAllAssignmentsByDateAndEmailQueryHandler(IAssignmentToUserRepository assignmentToUserRepository, IMapper mapper)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _mapper = mapper;
    }
    
    public async Task<List<AssignmentToUserDto>> Handle(GetAllAssignmentsByDateAndEmailQuery request, CancellationToken cancellationToken)
    {
        var assignments = await _assignmentToUserRepository
            .GetAllByPredicateAsync(predicate: p => 
                    p.User.Email == request.Email 
                    && p.StartTime.Month == request.Month 
                    && p.StartTime.Year == request.Year,
                includes: incl => incl.Assignment.Role);
        
        if (assignments.Count <= 0)
            throw new NotFoundException();
        
        return _mapper.Map<List<AssignmentToUserDto>>(assignments);
    }
}