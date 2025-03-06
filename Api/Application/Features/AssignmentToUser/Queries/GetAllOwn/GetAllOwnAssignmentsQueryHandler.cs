using System.Linq.Expressions;
using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUser.Common;
using Api.Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAllOwn;

public class GetAllOwnAssignmentsQueryHandler : IRequestHandler<GetAllOwnAssignmentsQuery, List<AssignmentToUserDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly UserManager<Data.Models.User> _userManager;

    public GetAllOwnAssignmentsQueryHandler(IMapper mapper, IUserService userService, IAssignmentToUserRepository assignmentToUserRepository, 
        UserManager<Data.Models.User> userManager)
    {
        _mapper = mapper;
        _userService = userService;
        _assignmentToUserRepository = assignmentToUserRepository;
        _userManager = userManager;
    }
    
    public async Task<List<AssignmentToUserDto>> Handle(GetAllOwnAssignmentsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(_userService.UserId);
        if (user is null)
            throw new NotFoundException("User not found");

        var userAssignments = await _assignmentToUserRepository.GetAllByPredicateAsync(
            predicate: a => a.UserId == user.Id, 
            includes: new Expression<Func<Domain.AssignmentToUser, object>>[]{incl => incl.Assignment, incl => incl.AssignmentToUserStatus});

        return _mapper.Map<List<AssignmentToUserDto>>(userAssignments);
    }
}