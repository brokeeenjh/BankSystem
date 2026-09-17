using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Domain.entities;
using BankSystem.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure.Repositories;

public class CardRepository : ICardRepository
{
    private readonly AppDbContext _dbContext;
    
    public CardRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CardEntity>> GetAllCardsAsync()
    {
        var cards =  await _dbContext.Cards
            .ToListAsync();
        
        return cards;
    }

    public async Task<CardEntity> GetCardByIdAsync(Guid cardId)
    {
        var card = await _dbContext.Cards
            .FirstOrDefaultAsync(x => x.CardId == cardId);

        if(card == null)
            throw new Exception("Card not found");
        
        return card;
    }

    public async Task<Guid> CreateCardAsync(CardEntity card)
    {
        await _dbContext.Cards.AddAsync(card);
        await _dbContext.SaveChangesAsync();
        
        return card.CardId;
    }

    public async Task DeleteCardAsync(Guid cardId)
    {
        var  card = await _dbContext.Cards.
            FirstOrDefaultAsync(x => x.CardId == cardId);
        if (card == null)
            throw new Exception("Card not found");
        _dbContext.Cards.Remove(card);
    }

    public async Task UpdateCardAsync(Guid cardId, int amount)
    {
        var card = await _dbContext.Cards.FirstOrDefaultAsync(x => x.CardId == cardId);
        
        if (card == null)
            throw new Exception("Card not found");
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> GetCardAmountAsync(Guid cardId)
    {
        var card = await _dbContext.Cards
            .FirstOrDefaultAsync(x => x.CardId == cardId);

        if (card == null)
            throw new Exception("there is no card");

        return card.Amount;
    }
}