using CleanArchitectureProject.Domain.Common;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.Events.ArtistEvents;

public class ArtistUpdatedEvent : EntityEvent<Artist>
{
    public ArtistUpdatedEvent(Artist artist)
        : base(artist, EntityEventType.Updated)
    {
    }
}