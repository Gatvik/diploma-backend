using Api.Application.Features.Assignment.Common;
using Api.Application.Features.AssignmentToUserStatus.Common;
using Api.Application.Features.User.Common;
using Api.Domain;

namespace Api.Application.Features.AssignmentToUser.Common;

public class AssignmentToUserDto
{
    public Guid Id { get; set; }
    public AssignmentDto Assignment { get; set; }
    public AssignmentToUserStatusDto AssignmentToUserStatus { get; set; }
    public UserDto User { get; set; }
    public string Details { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}