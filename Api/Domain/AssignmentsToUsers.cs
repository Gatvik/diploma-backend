using Api.Data.Models;
using Api.Domain.Common;

namespace Api.Domain;

public class AssignmentsToUsers : BaseEntity
{
    public bool IsCompleted { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Description { get; set; }
    
    public Guid AssignmentId { get; set; }
    public Assignment Assignment { get; set; }

    public Guid UserId { get; set; }
    public AppUser User { get; set; }
}