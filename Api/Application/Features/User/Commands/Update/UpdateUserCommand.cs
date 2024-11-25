using MediatR;

namespace Api.Application.Features.User.Commands.Update;

public class UpdateUserCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string Role { get; set; }
}