using Api.Application.Features.User.Common;
using MediatR;

namespace Api.Application.Features.User.Queries.GetById;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid UserId { get; set; }
}