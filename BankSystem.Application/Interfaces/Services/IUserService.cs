using BankSystem.Domain.entities;

namespace BankSystem.Application.Interfaces;

public interface IUserService
{
    public Task RegisterAsync(string userName, string email, string password);
    public Task<string> LoginAsync(string email, string password);
}