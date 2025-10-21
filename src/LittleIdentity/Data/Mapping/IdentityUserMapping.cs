using LittleIdentity.Abstractions.ObjectValue;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LitleIdentity.Data.Mapping;

public class IdentityUserMapping:
    IEntityTypeConfiguration<LittleIdentity.Abstractions.Entities.IdentityUser>
{
    public void Configure
        (EntityTypeBuilder<LittleIdentity.Abstractions.Entities.IdentityUser> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Users");

        builder.Property(x => x.Name)
            .HasMaxLength(120)
            .IsRequired();
        
        builder.Property(x => x.Password)
            .HasMaxLength(170)
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasConversion(x=>x.Address,x=>new Email(x))
            .HasColumnName("Email")
            .IsRequired();
    }
}