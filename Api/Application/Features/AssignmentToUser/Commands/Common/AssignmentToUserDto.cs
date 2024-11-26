using Api.Application.Features.Assignment.Common;
using Api.Application.Features.User.Common;

namespace Api.Application.Features.AssignmentToUser.Commands.Common;

public class AssignmentToUserDto
{
    public Guid Id { get; set; }
    public AssignmentDto Assignment { get; set; }
    public AppUserDto User { get; set; }
    public string Details { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsCompleted { get; set; }
}