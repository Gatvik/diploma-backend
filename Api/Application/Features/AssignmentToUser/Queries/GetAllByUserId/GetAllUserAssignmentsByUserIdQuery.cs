﻿using Api.Application.Features.AssignmentToUser.Common;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAllByUserId;

public class GetAllUserAssignmentsByUserIdQuery : IRequest<List<AssignmentToUserDto>>
{
    public Guid UserId { get; set; }
}