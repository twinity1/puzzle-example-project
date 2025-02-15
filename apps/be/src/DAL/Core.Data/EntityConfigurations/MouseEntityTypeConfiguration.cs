using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EntityConfigurations;

public class MouseEntityTypeConfiguration : IEntityTypeConfiguration<Mouse>
{
    public void Configure(EntityTypeBuilder<Mouse> builder)
    {
        builder.HasKey(m => m.Id);
        builder.HasIndex(m => m.Name);
        builder.Property(m => m.Name).IsRequired().HasMaxLength(255);
        builder.Property(m => m.Color).HasMaxLength(50);
    }
}
