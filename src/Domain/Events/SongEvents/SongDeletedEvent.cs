using CleanArchitectureProject.Domain.Common;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.Events.SongEvents;

public class SongDeletedEvent : EntityEvent<Song>
{
    public SongDeletedEvent(Song song)
        : base(song, EntityEventType.Deleted)
    {
    }
}