using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Artists.Queries.GetArtistById;

public record GetArtistByIdQuery(int Id) : IRequest<ArtistDto>;

public class GetArtistByIdQueryHandler : IRequestHandler<GetArtistByIdQuery, ArtistDto?>
{
    private readonly IApplicationDbContext _context;

    public GetArtistByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ArtistDto?> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Artists
            .AsNoTracking()
            .Where(a => a.Id == request.Id)
            .Select(a => new ArtistDto
            {
                Id = a.Id,
                Name = a.Name,
                Username = a.Username.Value,
                Bio = a.Bio,
                PayoutTier = a.PayoutTier.Name,
                Email = a.Email.Value
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}