using BankSystem.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSystem.Infrastructure.Configurations;

public class CardConfiguration : IEntityTypeConfiguration<CardEntity>
{
    public void Configure(EntityTypeBuilder<CardEntity> builder)
    {
        builder.HasKey(x => x.CardId);
        
        builder.HasOne(x => x.User).WithOne(x => x.Card).HasForeignKey<UserEntity>(x => x.CardId);
    }
}