using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.SongEvents;

public class SongUpdatedEvent : EntityEvent<Song>
{
    public SongUpdatedEvent(Song song)
        : base(song, EntityEventType.Updated)
    {
    }
}