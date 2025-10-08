using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.SongEvents;

public class SongDeletedEvent : EntityEvent<Song>
{
    public SongDeletedEvent(Song song)
        : base(song, EntityEventType.Deleted)
    {
    }
}