using Api.Application.Features.AssignmentToUser.Common;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAllByUserEmail;

public class GetAllAssignmentsByUserEmailQuery : IRequest<List<AssignmentToUserDto>>
{
    public string Email { get; set; }
}