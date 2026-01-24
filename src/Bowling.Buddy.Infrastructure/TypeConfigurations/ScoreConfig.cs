using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bowling.Buddy.Infrastructure.TypeConfigurations;

public class ScoreConfig : IEntityTypeConfiguration<Score>
{
    public void Configure(EntityTypeBuilder<Score> builder)
    {
        builder.ToTable("Scores", SchemaConstants.Bowling, t =>
        {
            t.HasCheckConstraint("CK_Scores_FinalScore_Range", "\"FinalScore\" >= 0 AND \"FinalScore\" <= 300");
        });
        
        builder.ConfigShadowProperties();
        builder.ConfigIdAsKey();
        
        builder.Property(s => s.FinalScore)
            .IsRequired();
        
        builder.HasOne(s => s.Game)
            .WithMany(g => g.Scores)
            .HasForeignKey(s => s.GameId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.Player)
            .WithMany(p => p.Scores)
            .HasForeignKey(s => s.PlayerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasIndex(s => new { s.PlayerId, s.GameId }).IsUnique();
        builder.HasIndex(s => s.GameId);
    }
}