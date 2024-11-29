using Api.Application.Contracts.Identity;
using Api.Application.Exceptions;
using Api.Application.Features.User.Common;
using Api.Data.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.User.Queries.GetSelf;

public class GetSelfQueryHandler : IRequestHandler<GetSelfQuery, UserDto>
{
    private readonly UserManager<Data.Models.User> _userManager;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetSelfQueryHandler(UserManager<Data.Models.User> userManager, IUserService userService, IMapper mapper)
    {
        _userManager = userManager;
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<UserDto> Handle(GetSelfQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(_userService.UserId);
        if (user is null)
            throw new NotFoundException();
        
        var role = (await _userManager.GetRolesAsync(user)).First();
        var userDto = _mapper.Map<UserDto>(user);
        userDto.Role = role;

        return userDto;
    }
}