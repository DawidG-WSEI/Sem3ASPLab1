using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Playlists.Queries.GetPlaylistById;

public record GetPlaylistByIdQuery(int Id) : IRequest<PlaylistDto?>;
public class GetPlaylistByIdQueryHandler : IRequestHandler<GetPlaylistByIdQuery, PlaylistDto?>
{
    private readonly IApplicationDbContext _context;
    public GetPlaylistByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PlaylistDto?> Handle(GetPlaylistByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Playlists
            .Include(p => p.Songs)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (entity == null) return null;

        return new PlaylistDto
        {
            Id = entity.Id,
            Title = entity.Title,
            ListenerId = entity.ListenerId,
            SongCount = entity.Songs.Count
        };
    }
}
