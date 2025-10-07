using CleanArchitectureProject.Application.Common.Interfaces;
using CleanArchitectureProject.Domain.Entities;
using CleanArchitectureProject.Domain.Events.ArtistEvents;
using MediatR;

namespace CleanArchitectureProject.Application.Artists.Commands.DeleteArtist;

public record DeleteArtistCommand(int Id) : IRequest;

public class DeleteArtistCommandHandler : IRequestHandler<DeleteArtistCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteArtistCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Artists.FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Artists.Remove(entity);

        entity.AddDomainEvent(new ArtistDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}