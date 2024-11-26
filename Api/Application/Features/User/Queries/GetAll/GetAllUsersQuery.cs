using Api.Application.Features.User.Common;
using MediatR;

namespace Api.Application.Features.User.Queries.GetAll;

public class GetAllUsersQuery : IRequest<List<AppUserDto>>
{
    
}