using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUser.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAll;

public class GetAllAssignmentsToUserQueryHandler : IRequestHandler<GetAllAssignmentsToUserQuery, List<AssignmentToUserDto>>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IMapper _mapper;

    public GetAllAssignmentsToUserQueryHandler(IAssignmentToUserRepository assignmentToUserRepository, IMapper mapper)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _mapper = mapper;
    }
    
    public async Task<List<AssignmentToUserDto>> Handle(GetAllAssignmentsToUserQuery request, CancellationToken cancellationToken)
    {
        var assignments = await _assignmentToUserRepository.GetAllAsync(incl => incl.Assignment.Role, incl => incl.User);
        if (assignments.Count == 0)
            throw new NotFoundException();

        return _mapper.Map<List<AssignmentToUserDto>>(assignments);
    }
}