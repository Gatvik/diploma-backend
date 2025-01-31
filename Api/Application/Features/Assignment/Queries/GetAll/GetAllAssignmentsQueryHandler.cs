using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
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
        var assignments = await _assignmentRepository.GetAllAsync(
            pageSize: request.PageSize, pageNumber: request.PageNumber, 
            includes: a => a.Role);

        if (assignments.Count == 0)
            throw new NotFoundException("Assignments not found");

        return _mapper.Map<List<AssignmentDto>>(assignments);
    }
}