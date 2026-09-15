using BankSystem.Application.Interfaces;
using MediatR;

namespace BankSystem.Application.Handlers.Command;

public record WithDrawCommand(Guid CardId, int amount) : IRequest<Task>;
public class WithDrawCommandHandler : IRequestHandler<WithDrawCommand, Task>
{
    private readonly ICardService _cardService;

    public WithDrawCommandHandler(ICardService cardService)
    {
        _cardService = cardService;
    }
    
    public async Task<Task> Handle(WithDrawCommand request, CancellationToken cancellationToken)
    {
        await _cardService.WithdrawAsync(request.CardId, request.amount);
        return Task.CompletedTask;
    }
}