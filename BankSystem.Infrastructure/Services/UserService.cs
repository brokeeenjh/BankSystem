using BankSystem.Application.Interfaces;
using BankSystem.Domain.entities;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IJwtProvider  _jwtProvider;
    public UserService(UserManager<UserEntity> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
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
        await _userManager.AddToRoleAsync(user, "User");
        await _userManager.CreateAsync(userEntity, password);
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            throw new Exception("there is no person with this email");

        var result = await _userManager.CheckPasswordAsync(user, password);

        if (!result)
            throw new Exception("Wrong password");

        var token = _jwtProvider.GenerateToken(user);
        
        return token;
    }
}