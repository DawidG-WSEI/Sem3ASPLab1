using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Playlists.Queries.GetPlaylistsWithPagination;

public record GetPlaylistsWithPaginationQuery : IRequest<PaginatedList<PlaylistDto>> { public int PageNumber { get; init; } = 1; public int PageSize { get; init; } = 10; public string? TitleFilter { get; init; } }
public class GetPlaylistsWithPaginationQueryHandler : IRequestHandler<GetPlaylistsWithPaginationQuery, PaginatedList<PlaylistDto>>
{
    private readonly IApplicationDbContext _context;
    public GetPlaylistsWithPaginationQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<PlaylistDto>> Handle(GetPlaylistsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Playlists
            .Include(p => p.Songs)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.TitleFilter))
            query = query.Where(p => p.Title.Contains(request.TitleFilter!));

        var total = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderBy(p => p.Id)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new PlaylistDto
            {
                Id = p.Id,
                Title = p.Title,
                ListenerId = p.ListenerId,
                SongCount = p.Songs.Count
            })
            .ToListAsync(cancellationToken);

        return new PaginatedList<PlaylistDto>(items, total, request.PageNumber, request.PageSize);
    }
}
