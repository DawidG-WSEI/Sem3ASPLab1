using CleanArchitectureProject.Domain.Common;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.Events.ArtistEvents
{
    public class ArtistDeletedEvent : EntityEvent<Artist>
    {
        public ArtistDeletedEvent(Artist artist)
            : base(artist, EntityEventType.Deleted)
        {
        }
    }
}