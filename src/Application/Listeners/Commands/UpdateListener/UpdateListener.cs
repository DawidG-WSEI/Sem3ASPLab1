using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions.ListenerExceptions;
using MediatR;

namespace CleanArchitecture.Application.Listeners.Commands.UpdateListener;

public record UpdateListenerCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
}

public class UpdateListenerCommandHandler : IRequestHandler<UpdateListenerCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateListenerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateListenerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Listeners.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
            throw new ListenerNotFoundException(request.Id);

        if (request.Name is not null)
            entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}