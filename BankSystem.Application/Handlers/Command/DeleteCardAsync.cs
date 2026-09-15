using BankSystem.Application.Interfaces;
using MediatR;

namespace BankSystem.Application.Handlers.Command;

public record DeleteCardRequest(Guid  CardId) : IRequest<Task>;
public class DeleteCardAsync : IRequestHandler<DeleteCardRequest, Task>
{
    private readonly ICardService _cardService;
    public DeleteCardAsync(ICardService cardService)
    {
        _cardService = cardService;
    }
    public async Task<Task> Handle(DeleteCardRequest request, CancellationToken cancellationToken)
    {
        await _cardService.DeleteCardAsync(request.CardId);
        return Task.CompletedTask;
    }
}