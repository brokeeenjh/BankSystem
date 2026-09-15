using BankSystem.Application.Interfaces;
using MediatR;

namespace BankSystem.Application.Handlers.Command;

public record LoginUserCommand(string userName, string password) : IRequest<string>;
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
{
    private readonly IUserService _userService;

    public LoginUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var token = await _userService.LoginAsync(request.userName, request.password);
        return token;
    }
}