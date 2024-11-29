using Api.Application.Features.User.Common;
using Api.Data.Models;
using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Features.User.Queries.GetAll;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly UserManager<Data.Models.User> _userManager;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(UserManager<Data.Models.User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    
    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users.ToListAsync(cancellationToken: cancellationToken);
        var userWithRolesList = new List<UserDto>();

        foreach (var user in users)
        {
            var userDto = _mapper.Map<UserDto>(user);
            var role = (await _userManager.GetRolesAsync(user)).First();

            userDto.Role = role;
            userWithRolesList.Add(userDto);
        }

        return userWithRolesList;
    }
}