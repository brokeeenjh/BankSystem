namespace BankSystem.Domain.entities;
using Microsoft.AspNetCore.Identity;
public class UserEntity : IdentityUser<Guid>
{
    public CardEntity  Card { get; set; }
    public Guid CardId { get; set; }
    public ICollection<RoleEntity> Roles { get; set; }
}