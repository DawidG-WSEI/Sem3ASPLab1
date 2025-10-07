using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Artist> Artists { get; }

    DbSet<Listener> Listeners { get; }

    DbSet<Song> Songs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
