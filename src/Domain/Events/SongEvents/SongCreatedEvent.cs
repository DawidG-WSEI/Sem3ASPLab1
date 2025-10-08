using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.SongEvents;

public class SongCreatedEvent : EntityEvent<Song>
{
    public SongCreatedEvent(Song song)
        : base(song, EntityEventType.Created)
    {
    }
}