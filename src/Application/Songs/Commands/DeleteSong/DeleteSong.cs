using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Events.SongEvents;
using CleanArchitecture.Domain.Exceptions.SongExceptions;

namespace CleanArchitecture.Application.Songs.Commands.DeleteSong;

public record DeleteSongCommand(int Id) : IRequest;

public class DeleteSongCommandHandler : IRequestHandler<DeleteSongCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteSongCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteSongCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Songs
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if(entity == null)
            throw new SongNotFoundException(request.Id);

        _context.Songs.Remove(entity);

        entity.AddDomainEvent(new SongDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }

}
