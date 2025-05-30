﻿using System.Linq.Expressions;
using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.AssignmentToUser.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAll;

public class GetAllAssignmentsToUserQueryHandler : IRequestHandler<GetAllAssignmentsToUserQuery, GetAllAssignmentsToUserQueryResponse>
{
    private readonly IAssignmentToUserRepository _assignmentToUserRepository;
    private readonly IMapper _mapper;

    public GetAllAssignmentsToUserQueryHandler(IAssignmentToUserRepository assignmentToUserRepository, IMapper mapper)
    {
        _assignmentToUserRepository = assignmentToUserRepository;
        _mapper = mapper;
    }
    
    public async Task<GetAllAssignmentsToUserQueryResponse> Handle(GetAllAssignmentsToUserQuery request, CancellationToken cancellationToken)
    {
        var assignments = await _assignmentToUserRepository.GetAllAsync(
            orderBy: x => x.StartTime,
            pageNumber: request.PageNumber, pageSize: request.PageSize, 
            includes: new Expression<Func<Domain.AssignmentToUser, object>>[]{ x => x.Assignment.Role, x => x.User, x => x.AssignmentToUserStatus });
        
        if (assignments.Count == 0)
            throw new NotFoundException();

        var response = new GetAllAssignmentsToUserQueryResponse
        {
            AssignmentsToUsers = _mapper.Map<List<AssignmentToUserDto>>(assignments),
            Count = _assignmentToUserRepository.Count()
        };

        return response;
    }
}