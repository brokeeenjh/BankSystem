using BankSystem.Application.Interfaces;
using BankSystem.Application.Interfaces.Repositories;
using MediatR;

namespace BankSystem.Application.Handlers.Query;

public record GetCardAmountQuery(Guid cardId) : IRequest<int>;
public class GetCardAmountQueryHandler : IRequestHandler<GetCardAmountQuery, int>
{
    private readonly ICardService  _cardService;

    public GetCardAmountQueryHandler(ICardService cardService)
    {
        _cardService = cardService;
    }
    
    public async Task<int> Handle(GetCardAmountQuery request, CancellationToken cancellationToken)
    {
        var amount = await _cardService.GetCardAmountAsync(request.cardId);
        
        return amount;
    }
}