using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bowling.Buddy.Infrastructure.TypeConfigurations;

public class GameConfig : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games", SchemaConstants.Bowling);
        builder.ConfigShadowProperties();
        builder.ConfigIdAsKey();
        
        builder.HasOne(g => g.Group)
            .WithMany(g => g.Games)
            .HasForeignKey(g => g.GroupId);
        
        builder.Property(g => g.DateTime)
            .IsRequired();
    }
}