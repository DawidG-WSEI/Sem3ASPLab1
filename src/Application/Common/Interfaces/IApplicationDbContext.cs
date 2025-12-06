using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Artist> Artists { get; }

    DbSet<Listener> Listeners { get; }

    DbSet<Song> Songs { get; }

    DbSet<Playlist> Playlists { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
