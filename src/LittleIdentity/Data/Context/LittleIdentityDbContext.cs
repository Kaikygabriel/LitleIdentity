using LitleIdentity.Data.Mapping;
using LitleIdentity.IdentityRole;
using LitleIdentity.IdentityUser;
using LittleIdentity.Abstractions.Entities;
using LittleIdentity.Abstractions.ObjectValue;
using Microsoft.EntityFrameworkCore;

namespace LitleIdentity.Data.Context;

public abstract class LittleIdentityDbContext<TUser> : DbContext
    where TUser : LittleIdentity.Abstractions.Entities.IdentityUser 
{
    public LittleIdentityDbContext()
    {
        
    }

    public LittleIdentityDbContext(DbContextOptions<LittleIdentityDbContext<TUser>>options ): base(options)
    {
        
    }
    public DbSet<TUser> Users { get; set; }
    public DbSet<LittleIdentity.Abstractions.ObjectValue.IdentityRole>Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new IdentityUserMapping());
    }
}
