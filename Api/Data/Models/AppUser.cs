using Api.Domain;
using Microsoft.AspNetCore.Identity;

namespace Api.Data.Models;

public class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    
    public ICollection<AssignmentsToUsers> AssignmentsToUsers { get; set; }

    public ICollection<Schedule> Schedules { get; set; }
}