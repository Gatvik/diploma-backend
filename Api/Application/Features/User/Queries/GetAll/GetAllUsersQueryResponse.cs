using Api.Application.Features.User.Common;

namespace Api.Application.Features.User.Queries.GetAll;

public class GetAllUsersQueryResponse
{
    public List<UserDto> Users { get; set; }
    public int Count { get; set; }
}