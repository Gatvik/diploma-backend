namespace Api.Application.Features.User.Common;

public class AppUserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
}