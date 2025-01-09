using MediatR;

namespace Api.Application.Features.Assignment.Commands.CreateAssignmentCommand;

public class CreateAssignmentCommand : IRequest<Unit>
{
    public string Name { get; set; }
    public Guid RoleId { get; set; }
}