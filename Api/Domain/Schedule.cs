using Api.Data.Models;
using Api.Domain.Common;

namespace Api.Domain;

public class Schedule : BaseEntity
{
    public DateOnly Date { get; set; }
    
    public Guid UserId { get; set; }
    public AppUser User { get; set; }

    public Guid ShiftTypeId { get; set; }
    public ShiftType ShiftType { get; set; }
}