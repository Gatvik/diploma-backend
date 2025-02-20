using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUser.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetById;

public class GetAssignmentToUserByIdQueryHandler : IRequestHandler<GetAssignmentToUserByIdQuery, AssignmentToUserDto>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public GetAssignmentToUserByIdQueryHandler(IAssignmentToUserRepository assignmentToUserRepository, IMapper mapper, IUserService userService)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _mapper = mapper;
        _userService = userService;
    }
    
    public async Task<AssignmentToUserDto> Handle(GetAssignmentToUserByIdQuery request, CancellationToken cancellationToken)
    {
        var assignmentToUser = await _assignmentToUserRepository.GetByIdAsync(request.Id, ass => ass.Assignment.Role);
        var userId = _userService.UserId;
        if (assignmentToUser is null)
            throw new NotFoundException("AssignmentToUser not found or you haven't enough rights to access it");
        if (assignmentToUser.UserId.ToString() != userId)
            throw new NotFoundException("AssignmentToUser not found or you haven't enough rights to access it");
        
        return _mapper.Map<AssignmentToUserDto>(assignmentToUser);
    }
}