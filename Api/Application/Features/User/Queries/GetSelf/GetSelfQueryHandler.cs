using Api.Application.Contracts.Identity;
using Api.Application.Features.User.Common;
using Api.Data.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.User.Queries.GetSelf;

public class GetSelfQueryHandler : IRequestHandler<GetSelfQuery, UserDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public GetSelfQueryHandler(UserManager<AppUser> userManager, IUserService userService, IMapper mapper)
    {
        _userManager = userManager;
        _userService = userService;
        _mapper = mapper;
    }
    
    public async Task<UserDto> Handle(GetSelfQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(_userService.UserId);

        return _mapper.Map<UserDto>(user);
    }
}