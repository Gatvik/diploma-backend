using Api.Domain.Common;

namespace Api.Domain;

public class AssignmentToUserStatus : BaseEntity
{
    public string Name { get; set; }

    public ICollection<AssignmentToUser> AssignmentToUsers { get; set; }
}