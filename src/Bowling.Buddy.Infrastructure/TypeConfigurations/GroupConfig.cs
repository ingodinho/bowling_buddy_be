using Bowling.Buddy.Domain.Entities;
using Bowling.Buddy.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bowling.Buddy.Infrastructure.TypeConfigurations;

public class GroupConfig : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups", SchemaConstants.Bowling);
        builder.ConfigShadowProperties();
        builder.ConfigIdAsKey();
        
        builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}