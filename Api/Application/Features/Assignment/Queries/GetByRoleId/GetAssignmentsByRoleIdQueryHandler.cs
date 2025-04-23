using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.Assignment.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Assignment.Queries.GetByRoleId;

public class GetAssignmentsByRoleIdQueryHandler : IRequestHandler<GetAssignmentsByRoleIdQuery, GetAssignmentsByRoleIdResponse>
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly IMapper _mapper;

    public GetAssignmentsByRoleIdQueryHandler(IAssignmentRepository assignmentRepository, IMapper mapper)
    {
        _assignmentRepository = assignmentRepository;
        _mapper = mapper;
    }
    
    public async Task<GetAssignmentsByRoleIdResponse> Handle(GetAssignmentsByRoleIdQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Domain.Assignment> assignments;

        if (request.PageNumber is null && request.PageSize is null)
            assignments = await _assignmentRepository.GetAllByPredicateAsync(a => a.RoleId == request.RoleId,
                includes: a => a.Role);
        else
            assignments = await _assignmentRepository.GetAllByPredicateAsync(a => a.RoleId == request.RoleId,
                pageNumber: request.PageNumber, pageSize: request.PageSize,
                includes: a => a.Role);
            

        if (assignments.Count == 0)
            throw new NotFoundException("Assignments not found");

        var response = new GetAssignmentsByRoleIdResponse()
        {
            Assignments = _mapper.Map<List<AssignmentDto>>(assignments),
            Count = _assignmentRepository.Count()
        };

        return response;

    }
}