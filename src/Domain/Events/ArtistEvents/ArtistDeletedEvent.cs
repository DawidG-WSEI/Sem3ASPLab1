using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.ArtistEvents
{
    public class ArtistDeletedEvent : EntityEvent<Artist>
    {
        public ArtistDeletedEvent(Artist artist)
            : base(artist, EntityEventType.Deleted)
        {
        }
    }
}