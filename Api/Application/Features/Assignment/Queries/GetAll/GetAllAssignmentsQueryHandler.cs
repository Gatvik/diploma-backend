using Api.Application.Contracts.Persistence;
using Api.Application.Features.Assignment.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Assignment.Queries.GetAll;

public class GetAllAssignmentsQueryHandler : IRequestHandler<GetAllAssignmentsQuery, List<AssignmentDto>>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;

    public GetAllAssignmentsQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
    {
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
    }
    
    public async Task<List<AssignmentDto>> Handle(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var assignments = await _assignmentRepository.GetAllAsync(a => a.Role);

        return _mapper.Map<List<AssignmentDto>>(assignments);
    }
}