using System.Reflection;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Song> Songs => Set<Song>();
    public DbSet<Artist> Artists => Set<Artist>();
    public DbSet<Listener> Listeners => Set<Listener>();
    public DbSet<Playlist> Playlists => Set<Playlist>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Configure value objects as owned types for Artist
        builder.Entity<Artist>()
            .OwnsOne(a => a.Username, b => b.Property(u => u.Value).HasColumnName("Username"));
        builder.Entity<Artist>()
            .OwnsOne(a => a.Email, b => b.Property(e => e.Value).HasColumnName("Email"));

        // Configure value objects as owned types for Listener
        builder.Entity<Listener>()
            .OwnsOne(l => l.Username, b => b.Property(u => u.Value).HasColumnName("Username"));
        builder.Entity<Listener>()
            .OwnsOne(l => l.Email, b => b.Property(e => e.Value).HasColumnName("Email"));

        builder.Entity<Artist>()
            .HasIndex(a => a.UserId)
            .IsUnique();

        builder.Entity<Listener>()
            .HasIndex(l => l.UserId)
            .IsUnique();

        builder.Entity<Playlist>()
            .HasMany(p => p.Songs)
            .WithMany();
    }
}
