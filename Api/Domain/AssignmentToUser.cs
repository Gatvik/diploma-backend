using Api.Data.Models;
using Api.Domain.Common;

namespace Api.Domain;

public class AssignmentToUser : BaseEntity
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Details { get; set; }

    public Guid AssignmentToUserStatusId { get; set; }
    public AssignmentToUserStatus AssignmentToUserStatus { get; set; }
    
    public Guid AssignmentId { get; set; }
    public Assignment Assignment { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}