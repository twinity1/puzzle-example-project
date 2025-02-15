using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Core.Data.Context;

public interface ICoreDataContext : IDisposable, IAsyncDisposable
{
    DbSet<Cat> Cats { get; }
    DbSet<Dog> Dogs { get; }
    DbSet<Mouse> Mice { get; }
}
