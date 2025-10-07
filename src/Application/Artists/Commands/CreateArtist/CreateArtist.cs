using CleanArchitectureProject.Application.Common.Interfaces;
using CleanArchitectureProject.Domain.Entities;
using CleanArchitectureProject.Domain.Events.ArtistEvents;
using CleanArchitectureProject.Domain.Exceptions.Common;
using CleanArchitectureProject.Domain.ValueObjects;
using CleanArchitectureProject.Domain.Enums;
using CleanArchitectureProject.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitectureProject.Application.Artists.Commands.CreateArtist;

public record CreateArtistCommand : IRequest<int>
{
    public string? UserId { get; init; }
    public string Name { get; init; } = default!;
    public string Username { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Bio { get; init; } = string.Empty;
    public string PayoutTier { get; init; } = default!;
    public string? Password { get; init; } = default!;
}

public class CreateArtistCommandHandler : IRequestHandler<CreateArtistCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IIdentityService _identityService;

    public CreateArtistCommandHandler(IApplicationDbContext context, IIdentityService identityService)
    {
        _context = context;
        _identityService = identityService;
    }

    public async Task<int> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
    {
        if (_context.Artists.Any(a => a.Email.Value == request.Email) ||
            _context.Listeners.Any(l => l.Email.Value == request.Email))
        {
            throw new UserAlreadyExistsException(request.Email, UserType.Artist);
        }

        string userId;
        if (string.IsNullOrEmpty(request.UserId))
        {
            // Create a new user via the identity service
            var (result, createdUserId) = await _identityService.CreateUserAsync(request.Username, request.Email, request.Password!, UserType.Artist);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors));
            userId = createdUserId;
        }
        else
        {
            userId = request.UserId;
        }   

        var entity = new Artist
        {
            UserId = userId,
            Name = request.Name,
            Username = new Domain.ValueObjects.Username(request.Username),
            Email = new Domain.ValueObjects.EmailAddress(request.Email),
            Bio = request.Bio,
            PayoutTier = new Domain.ValueObjects.PayoutTier(request.PayoutTier),
        };   

        entity.AddDomainEvent(new ArtistCreatedEvent(entity));  

        _context.Artists.Add(entity);   

        await _context.SaveChangesAsync(cancellationToken); 

        return entity.Id;
    }
}