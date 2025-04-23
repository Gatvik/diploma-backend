using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.Assignment.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Assignment.Queries.GetAll;

public class GetAllAssignmentsQueryHandler : IRequestHandler<GetAllAssignmentsQuery, GetAllAssignmentsQueryResponse>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;

    public GetAllAssignmentsQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
    {
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
    }
    
    public async Task<GetAllAssignmentsQueryResponse> Handle(GetAllAssignmentsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Domain.Assignment> assignments;
        
        if (request.PageNumber is null && request.PageSize is null)
            assignments = await _assignmentRepository.GetAllAsync(includes: a => a.Role);
        else 
            assignments = await _assignmentRepository.GetAllAsync(
                pageSize: request.PageSize, pageNumber: request.PageNumber, 
                includes: a => a.Role);

        if (assignments.Count == 0)
            throw new NotFoundException("Assignments not found");

        var response = new GetAllAssignmentsQueryResponse
        {
            Assignments = _mapper.Map<List<AssignmentDto>>(assignments),
            Count = _assignmentRepository.Count()
        };

        return response;
    }
}