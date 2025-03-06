using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUserStatus.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUserStatus.Queries.GetAll;

public class GetAllAssignmentToUserStatusesQueryHandler : IRequestHandler<GetAllAssignmentToUserStatusesQuery, List<AssignmentToUserStatusDto>>
{
    private readonly IAssignmentToUserStatusRepository _assignmentToUserStatusRepository;
    private readonly IMapper _mapper;

    public GetAllAssignmentToUserStatusesQueryHandler(IAssignmentToUserStatusRepository assignmentToUserStatusRepository, IMapper mapper)
    {
        _assignmentToUserStatusRepository = assignmentToUserStatusRepository;
        _mapper = mapper;
    }
    
    public async Task<List<AssignmentToUserStatusDto>> Handle(GetAllAssignmentToUserStatusesQuery request, CancellationToken cancellationToken)
    {
        var statuses = await _assignmentToUserStatusRepository.GetAllAsync();
        if (statuses.Count == 0)
            throw new NotFoundException("AssignmentToUserStatuses not found");

        return _mapper.Map<List<AssignmentToUserStatusDto>>(statuses);
    }
}