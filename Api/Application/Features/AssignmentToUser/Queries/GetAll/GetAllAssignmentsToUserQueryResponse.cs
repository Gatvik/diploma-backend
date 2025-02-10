using Api.Application.Features.Assignment.Common;
using Api.Application.Features.AssignmentToUser.Common;

namespace Api.Application.Features.AssignmentToUser.Queries.GetAll;

public class GetAllAssignmentsToUserQueryResponse
{
    public List<AssignmentToUserDto> AssignmentsToUsers { get; set; }
    public int Count { get; set; }
}