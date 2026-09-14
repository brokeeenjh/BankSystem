using BankSystem.Domain.entities;

namespace BankSystem.Application.Interfaces;

public interface IJwtProvider
{
    public string GenerateToken(UserEntity  user);
}