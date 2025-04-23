using Api.Application.Features.Assignment.Common;
using MediatR;

namespace Api.Application.Features.Assignment.Queries.GetByRoleId;

public class GetAssignmentsByRoleIdQuery : IRequest<GetAssignmentsByRoleIdResponse>
{
    public Guid RoleId { get; set; }
    public required int? PageNumber { get; set; }
    public required int? PageSize { get; set; }
}