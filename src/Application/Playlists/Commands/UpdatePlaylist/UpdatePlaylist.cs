using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events.PlaylistEvents;
using CleanArchitecture.Domain.Exceptions.ListenerExceptions;
using CleanArchitecture.Domain.Exceptions.PlaylistExceptions;
using MediatR;

namespace CleanArchitecture.Application.Playlists.Commands.UpdatePlaylist;

public record UpdatePlaylistCommand : IRequest 
{ 
    public int Id { get; init; } 
    public string? Title { get; init; } 
}

public class UpdatePlaylistCommandHandler : IRequestHandler<UpdatePlaylistCommand>
{
    private readonly IApplicationDbContext _context;
    public UpdatePlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdatePlaylistCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Playlists.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null)
            throw new PlaylistNotFoundException(request.Id);

        if (!string.IsNullOrWhiteSpace(request.Title))
            entity.Title = request.Title;

        entity.AddDomainEvent(new PlaylistCreatedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
