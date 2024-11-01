using Api.Domain;
using Microsoft.AspNetCore.Identity;

namespace Api.Data.Models;

public class AppRole : IdentityRole<Guid>
{
    public ICollection<Assignment> Assignments { get; set; }
}