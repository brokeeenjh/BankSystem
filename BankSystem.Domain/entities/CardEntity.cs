namespace BankSystem.Domain.entities;

public class CardEntity
{
    public Guid CardId { get; set; }
    public int Amount { get; set; }
    public string CardNumber { get; set; }
    public string CardHolderName { get; set; }
    public DateTime CardExpirationDate { get; set; }
    public string CardSecurityNumber { get; set; }
    public DateTime CardSecurityExpirationDate { get; set; }
    
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
}