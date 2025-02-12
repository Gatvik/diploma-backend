using Api.Application.Features.AssignmentToUser.Common;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAllOwnByDate;

public class GetAllOwnAssignmentsByDateQuery : IRequest<List<AssignmentToUserDto>>
{
    public int Month { get; set; }
    public int Year { get; set; }
}