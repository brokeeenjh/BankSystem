using BankSystem.Application.Interfaces;
using BankSystem.Application.Interfaces.Repositories;
using BankSystem.Domain.entities;
using Microsoft.AspNetCore.Identity;

namespace BankSystem.Infrastructure.Services;

public class CardService : ICardService
{
    private readonly ICardRepository  _cardRepository;
    private readonly UserManager<UserEntity>  _userManager;
    public CardService(ICardRepository cardRepository, UserManager<UserEntity> userManager)
    {
        _cardRepository = cardRepository;
        _userManager = userManager;
    }
    
    public async Task<Guid> CreateCardAsync(string userName, string email, string password)
    {
        if(string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            throw new ArgumentNullException(nameof(userName) + ", " + nameof(email) + ", " + nameof(password));
        
        var user = await _userManager.FindByEmailAsync(email);
        
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        var card = new CardEntity()
        {
            CardId = Guid.NewGuid(),
            UserId = user.Id,
            CardHolderName = user.UserName,
            CardExpirationDate = DateTime.UtcNow.AddYears(2),
            CardSecurityNumber = Guid.NewGuid().ToString(),
            CardSecurityExpirationDate = DateTime.UtcNow.AddMonths(3)
        };

        await _cardRepository.CreateCardAsync(card);

        return card.CardId;
    }

    public async Task DeleteCardAsync(Guid cardId)
    {
        var card = await _cardRepository.GetCardByIdAsync(cardId);
        
        if(card == null)
            throw new ArgumentNullException(nameof(card));
        
        await _cardRepository.DeleteCardAsync(cardId);
    }

    public async Task WithdrawAsync(Guid cardId, int amount)
    {
        var card =  await _cardRepository.GetCardByIdAsync(cardId);
        
        if (card == null)
            throw new ArgumentNullException(nameof(card));
        
        if(amount < 0 || amount > card.Amount)
            throw new ArgumentOutOfRangeException(nameof(amount));
        
        card.Amount -= amount;

        await _cardRepository.UpdateCardAsync(cardId, card.Amount);
    }

    public async Task DepositAsync(Guid cardId, int amount)
    {
        var card =  await _cardRepository.GetCardByIdAsync(cardId);
        
        if (card == null)
            throw new ArgumentNullException(nameof(card));
        
        if(amount < 0 || amount > card.Amount)
            throw new ArgumentOutOfRangeException(nameof(amount));
        
        card.Amount += amount;

        await _cardRepository.UpdateCardAsync(cardId, card.Amount);
    }
}