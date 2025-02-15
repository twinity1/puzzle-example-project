using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EntityConfigurations;

public class DogEntityTypeConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.HasIndex(d => d.Name);
        builder.HasIndex(d => d.Breed);
        builder.Property(d => d.Breed).IsRequired(false); //Breed is optional
    }
}
