using CleanArchitectureProject.Domain.Common;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.Events.SongEvents;

public class SongCreatedEvent : EntityEvent<Song>
{
    public SongCreatedEvent(Song song)
        : base(song, EntityEventType.Created)
    {
    }
}