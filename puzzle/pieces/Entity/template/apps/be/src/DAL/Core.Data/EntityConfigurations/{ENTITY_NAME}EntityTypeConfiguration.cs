using Example.Module.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Module.Core.Data.EntityConfigurations;

public class ExampleEntityTypeConfiguration : IEntityTypeConfiguration<Example>
{
    public void Configure(EntityTypeBuilder<Example> builder)
    {
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.Code);
    }
}
