using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUserStatus.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUserStatus.Queries.GetById;

public class GetAssignmentToUserStatusByIdQueryHandler : IRequestHandler<GetAssignmentToUserStatusByIdQuery, AssignmentToUserStatusDto>
{
    private readonly IAssignmentToUserStatusRepository _assignmentToUserStatusRepository;
    private readonly IMapper _mapper;

    public GetAssignmentToUserStatusByIdQueryHandler(IAssignmentToUserStatusRepository assignmentToUserStatusRepository, IMapper mapper)
    {
        _assignmentToUserStatusRepository = assignmentToUserStatusRepository;
        _mapper = mapper;
    }
    
    public async Task<AssignmentToUserStatusDto> Handle(GetAssignmentToUserStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var status = await _assignmentToUserStatusRepository.GetByIdAsync(request.Id);
        if (status is null)
            throw new NotFoundException("AssignmentToUserStatus not found");

        return _mapper.Map<AssignmentToUserStatusDto>(status);
    }
}