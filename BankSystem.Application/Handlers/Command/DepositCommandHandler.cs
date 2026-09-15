using BankSystem.Application.Interfaces;
using MediatR;

namespace BankSystem.Application.Handlers.Command;

public record DepositCommand(Guid cardId, int amount) : IRequest<Task>;
public class DepositCommandHandler : IRequestHandler<DepositCommand, Task>
{
    private readonly ICardService  _cardService;
    public DepositCommandHandler(ICardService cardService)
    {
        _cardService = cardService;
    }
    public async Task<Task> Handle(DepositCommand request, CancellationToken cancellationToken)
    {
        await _cardService.DepositAsync(request.cardId,  request.amount);
        return Task.CompletedTask;
    }
}