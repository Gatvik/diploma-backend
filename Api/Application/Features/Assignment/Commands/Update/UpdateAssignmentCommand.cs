using MediatR;

namespace Api.Application.Features.Assignment.Commands.Update;

public class UpdateAssignmentCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid RoleId { get; set; }
}