using Api.Application.Features.AssignmentToUser.Common;
using MediatR;

namespace Api.Application.Features.AssignmentToUser.Queries.GetById;

public class GetAssignmentToUserByIdQuery : IRequest<AssignmentToUserDto>
{
    public Guid Id { get; set; }
}