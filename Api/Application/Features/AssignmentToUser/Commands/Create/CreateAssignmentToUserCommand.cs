using MediatR;

namespace Api.Application.Features.AssignmentToUser.Commands.Create;

public class CreateAssignmentToUserCommand : IRequest<Unit>
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Details { get; set; }
    
    public Guid AssignmentId { get; set; }
    public Guid UserId { get; set; }
}