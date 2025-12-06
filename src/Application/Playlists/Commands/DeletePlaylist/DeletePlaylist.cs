using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events.PlaylistEvents;
using CleanArchitecture.Domain.Exceptions.PlaylistExceptions;
using MediatR;

namespace CleanArchitecture.Application.Playlists.Commands.DeletePlaylist;

public record DeletePlaylistCommand(int Id) : IRequest;
public class DeletePlaylistCommandHandler : IRequestHandler<DeletePlaylistCommand>
{
    private readonly IApplicationDbContext _context;
    public DeletePlaylistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeletePlaylistCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Playlists.FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null)
            throw new PlaylistNotFoundException(request.Id);

        _context.Playlists.Remove(entity);

        entity.AddDomainEvent(new PlaylistCreatedEvent(entity)); // reuse event as deletion notification body is minimal

        await _context.SaveChangesAsync(cancellationToken);
    }
}
