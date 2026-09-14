using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BankSystem.Application.Interfaces;
using BankSystem.Domain.entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BankSystem.Application.Auth;

public class JwtProvider : IJwtProvider
{
    private readonly IConfiguration _configuration;
    public JwtProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(UserEntity user)
    {
        var secretKey = _configuration.GetSection("AuthSettings").GetValue<string>("SecretKey");
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.Add(_configuration.GetSection("AuthSettings").GetValue<TimeSpan>("Expires")));
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}