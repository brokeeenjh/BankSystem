namespace BankSystem.Domain.entities;

public class UserEntity :Ide
{
    public CardEntity  Card { get; set; }
    public Guid CardId { get; set; }
}