using BankSystem.Application.Interfaces;
using MediatR;

namespace BankSystem.Application.Handlers.Command;

public record RegisterUserCommand(string userName, string Email, string Password) : IRequest<bool>;
public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    private readonly IUserService  _userService;

    public RegisterUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.RegisterAsync(request.userName, request.Email, request.Password);
        return true;
    }
}