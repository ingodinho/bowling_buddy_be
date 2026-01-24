using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bowling.Buddy.Infrastructure.TypeConfigurations;

public class ScoreConfig : IEntityTypeConfiguration<Score>
{
    public void Configure(EntityTypeBuilder<Score> builder)
    {
        builder.ToTable("Scores", SchemaConstants.Bowling);
        builder.ConfigShadowProperties();
        builder.ConfigIdAsKey();
        
        builder.Property(s => s.FinalScore)
            .IsRequired();
        
        builder.HasOne(s => s.Game)
            .WithMany(g => g.Scores)
            .HasForeignKey(s => s.GameId);
        
        builder.HasOne(s => s.Player)
            .WithMany(p => p.Scores)
            .HasForeignKey(s => s.PlayerId);
    }
}