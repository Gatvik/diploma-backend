using Api.Application.Features.AppRole.Common;

namespace Api.Application.Features.User.Common;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string Role { get; set; }
}