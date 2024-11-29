using Api.Domain;
using Microsoft.AspNetCore.Identity;

namespace Api.Data.Models;

public class User : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    
    public ICollection<AssignmentToUser> AssignmentsToUsers { get; set; }
    public ICollection<ItemHistory> ItemHistories { get; set; }
}