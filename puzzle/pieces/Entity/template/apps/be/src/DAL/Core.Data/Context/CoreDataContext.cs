using Core.Data.Entities;
using Core.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace Core.Data.Context;

public class CoreDataContext : DbContext, ICoreDataContext
{
    public DbSet<Example> Examples => Set<Example>();
}
