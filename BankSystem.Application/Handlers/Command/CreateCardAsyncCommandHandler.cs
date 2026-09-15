using BankSystem.Application.Interfaces;
using MediatR;

namespace BankSystem.Application.Handlers.Command;

public record CreateCardAsyncCommand(string UserName, string Email, string Password) : IRequest<Task>;
public class CreateCardAsyncCommandHandler : IRequestHandler<CreateCardAsyncCommand, Task>
{
    private readonly ICardService  _cardService;

    public CreateCardAsyncCommandHandler(ICardService cardService)
    {
        _cardService = cardService;
    }
    
    public async Task<Task> Handle(CreateCardAsyncCommand request, CancellationToken cancellationToken)
    {
        await _cardService.CreateCardAsync(request.UserName,request.Email, request.Password);
        return Task.CompletedTask;
    }
}