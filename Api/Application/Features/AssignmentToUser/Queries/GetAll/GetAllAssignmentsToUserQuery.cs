using Api.Application.Features.AssignmentToUser.Common;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAll;

public class GetAllAssignmentsToUserQuery : IRequest<List<AssignmentToUserDto>>
{
    
}