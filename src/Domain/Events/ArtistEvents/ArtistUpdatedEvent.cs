using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.ArtistEvents;

public class ArtistUpdatedEvent : EntityEvent<Artist>
{
    public ArtistUpdatedEvent(Artist artist)
        : base(artist, EntityEventType.Updated)
    {
    }
}