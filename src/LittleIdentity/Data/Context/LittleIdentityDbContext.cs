using LitleIdentity.Data.Mapping;
using LittleIdentity.Abstractions.Entities;
using Microsoft.EntityFrameworkCore;

namespace LitleIdentity.Data.Context;

public abstract class LittleIdentityDbContext<TUser> : DbContext
    where TUser : LittleIdentity.Abstractions.Entities.IdentityUser 
{
    public DbSet<TUser> Users { get; set; }
    public DbSet<IdentityRole>Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IdentityUserMapping());
    }
}