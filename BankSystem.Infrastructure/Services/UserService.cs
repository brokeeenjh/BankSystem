using BankSystem.Application.Interfaces;
using BankSystem.Domain.entities;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<UserEntity> _userManager;
    public UserService(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }
    public async Task RegisterAsync(string userName, string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        
        if (user != null)
            throw new Exception("User with same email already exists");

        var userEntity = new UserEntity
        {
            UserName = userName,
            Email = email,
        };
    }

    public Task<string> LoginAsync(string userName, string password)
    {
        throw new NotImplementedException();
    }
}