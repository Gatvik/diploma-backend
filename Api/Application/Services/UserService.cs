﻿using System.Security.Claims;
using Api.Application.Contracts.Identity;

namespace Api.Application.Services;

public class UserService : IUserService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    // public async Task<List<User>> GetMembers()
    // {
    //     var employees = await _userManager.GetUsersInRoleAsync("Member");
    //     return employees.Select(q => new User()
    //     {
    //         Id = q.Id,
    //         Email = q.Email,
    //         FirstName = q.FirstName,
    //         LastName = q.LastName
    //     }).ToList();
    // }
    //
    // public async Task<User> GetMember(string userId)
    // {
    //     var member = await _userManager.FindByIdAsync(userId);
    //     
    //     if (member is null)
    //         throw new NotFoundException($"User with {userId} not found.", userId);
    //     
    //     return new User()
    //     {
    //         Email = member.Email!,
    //         Id = member.Id,
    //         FirstName = member.FirstName,
    //         LastName = member.LastName
    //     };
    // }

    public string UserId => _contextAccessor.HttpContext?.User?.FindFirstValue("uid")!;
}