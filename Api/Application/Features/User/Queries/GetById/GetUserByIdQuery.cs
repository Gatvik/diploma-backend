using Api.Application.Features.User.Common;
using MediatR;

namespace Api.Application.Features.User.Queries.GetById;

public class GetUserByIdQuery : IRequest<AppUserDto>
{
    public Guid UserId { get; set; }
}