using Bowling.Buddy.Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bowling.Buddy.Infrastructure.TypeConfigurations;

public static class CommonTypeConfigs
{
    public static void ConfigShadowProperties<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class
    {
        builder.Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property<DateTime?>("DeletedAt");
        builder.Property<DateTime?>("UpdatedAt");
        
        builder.HasQueryFilter(x => EF.Property<DateTime?>(x, "DeletedAt") == null);
    }
    
    public static void ConfigIdAsKey<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IBaseIdEntity
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .IsRequired();
    }
}