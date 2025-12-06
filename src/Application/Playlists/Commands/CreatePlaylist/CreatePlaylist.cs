using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events.PlaylistEvents;
using CleanArchitecture.Domain.Exceptions.ListenerExceptions;
using MediatR;

namespace CleanArchitecture.Application.Playlists.Commands.CreatePlaylist;

public record CreatePlaylistCommand : IRequest<int> 
{ 
    public string Title { get; init; } = default!; 
    public int ListenerId { get; init; } 
}

public class CreatePlaylistCommandHandler : IRequestHandler<CreatePlaylistCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePlaylistCommand request, CancellationToken cancellationToken)
    {
        var listener = await _context.Listeners.FindAsync(new object[] { request.ListenerId }, cancellationToken);
        if (listener == null)
            throw new ListenerNotFoundException(request.ListenerId);

        var entity = new Playlist
        {
            Title = request.Title,
            ListenerId = request.ListenerId
        };

        entity.AddDomainEvent(new PlaylistCreatedEvent(entity));

        _context.Playlists.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
