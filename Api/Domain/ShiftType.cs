using Api.Domain.Common;

namespace Api.Domain;

public class ShiftType : BaseEntity
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }

    public ICollection<Schedule> Schedules { get; set; }
}