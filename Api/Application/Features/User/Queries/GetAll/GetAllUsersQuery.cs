using Api.Application.Features.User.Common;
using MediatR;

namespace Api.Application.Features.User.Queries.GetAll;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
    public required int PageNumber { get; set; }
    public required int PageSize { get; set; }
}