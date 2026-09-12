using Microsoft.AspNetCore.Identity;

namespace BankSystem.Domain.entities;

public class RoleEntity : IdentityRole<Guid>
{
    public UserEntity? User { get; set; }
    public Guid UserId { get; set; }
}