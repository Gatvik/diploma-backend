using Api.Application.Features.AssignmentToUser.Common;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAllByDate;

public class GetAllAssignmentsByDateAndEmailQuery : IRequest<List<AssignmentToUserDto>>
{
    public string Email { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int Day { get; set; }
}