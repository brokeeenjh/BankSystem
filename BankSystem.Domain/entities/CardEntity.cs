namespace BankSystem.Domain.entities;

public class CardEntity
{
    public Guid CardId { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public string CardExpirationDate { get; set; }
    public string CardSecurityNumber { get; set; }
    public string CardSecurityExpirationDate { get; set; }
    
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
}