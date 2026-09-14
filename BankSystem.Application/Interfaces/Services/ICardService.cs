namespace BankSystem.Application.Interfaces;

public interface ICardService
{
    public Task<Guid> CreateCardAsync(string userName, string email, string password);
    public Task DeleteCardAsync(Guid cardId);
    public Task WithdrawAsync(Guid cardId, int amount);
    public Task DepositAsync(Guid cardId, int amount);
}