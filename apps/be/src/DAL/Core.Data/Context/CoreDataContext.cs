using Core.Data.Entities;
using Core.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace Core.Data.Context;

public class CoreDataContext : DbContext, ICoreDataContext
{
    public DbSet<Cat> Cats => Set<Cat>();
    public DbSet<Dog> Dogs => Set<Dog>();
    public DbSet<Mouse> Mice => Set<Mouse>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CatEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DogEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MouseEntityTypeConfiguration());
    }
}
