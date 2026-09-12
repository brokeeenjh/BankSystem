using BankSystem.Domain.entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure.DbContext;

public class AppDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
{
    public DbSet<CardEntity> Cards { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}