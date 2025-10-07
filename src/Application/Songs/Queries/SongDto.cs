using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Songs.Queries;

public class SongDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int ArtistId { get; set; }
    public int ListenedTimes { get; set; }
}