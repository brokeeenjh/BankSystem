using BankSystem.Domain.entities;

namespace BankSystem.Application.Interfaces.Repositories;

public interface ICardRepository
{
    public Task<IEnumerable<CardEntity>> GetAllCardsAsync();
    public Task<CardEntity> GetCardByIdAsync(Guid  cardId);
    public Task<Guid> CreateCardAsync(CardEntity card);
    public Task DeleteCardAsync(Guid cardId);
    public Task UpdateCardAsync(Guid cardId, int amount);
   
}