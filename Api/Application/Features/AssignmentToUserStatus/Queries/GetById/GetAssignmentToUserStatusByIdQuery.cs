using Api.Application.Features.AssignmentToUserStatus.Common;
using MediatR;

namespace Api.Application.Features.AssignmentToUserStatus.Queries.GetById;

public class GetAssignmentToUserStatusByIdQuery : IRequest<AssignmentToUserStatusDto>
{
    public Guid Id { get; set; }
}