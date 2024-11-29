using Api.Application.Exceptions;
using Api.Application.Features.User.Common;
using Api.Data.Models;
using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.User.Queries.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly UserManager<Data.Models.User> _userManager;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(UserManager<Data.Models.User> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user is null)
            throw new NotFoundException();
        
        var role = (await _userManager.GetRolesAsync(user)).First();
        var userDto = _mapper.Map<UserDto>(user);
        userDto.Role = role;

        return userDto;
    }
}