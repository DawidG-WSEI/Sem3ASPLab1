using CleanArchitectureProject.Domain.Common;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.Events.SongEvents;

public class SongUpdatedEvent : EntityEvent<Song>
{
    public SongUpdatedEvent(Song song)
        : base(song, EntityEventType.Updated)
    {
    }
}