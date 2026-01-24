using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bowling.Buddy.Infrastructure.TypeConfigurations;

public class PlayerConfig : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.ToTable("Players", SchemaConstants.Bowling);
        builder.ConfigShadowProperties();
        builder.ConfigIdAsKey();
        
        builder.Property(p => p.DisplayName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(p => p.GroupId)
            .IsRequired();
        
        builder.HasOne(p => p.Group)
            .WithMany(p => p.Players)
            .HasForeignKey(p => p.GroupId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(p => p.GroupId);
    }
}