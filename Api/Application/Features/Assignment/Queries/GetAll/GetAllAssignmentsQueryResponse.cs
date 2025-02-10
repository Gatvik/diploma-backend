using Api.Application.Features.Assignment.Common;

namespace Api.Application.Features.Assignment.Queries.GetAll;

public class GetAllAssignmentsQueryResponse
{
    public List<AssignmentDto> Assignments { get; set; }
    public int Count { get; set; }
}