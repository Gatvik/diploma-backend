using Api.Application.Features.Assignment.Common;

namespace Api.Application.Features.Assignment.Queries.GetByRoleId;

public class GetAssignmentsByRoleIdResponse
{
    public List<AssignmentDto> Assignments { get; set; }
    public int Count { get; set; }
}