using MediatR;

namespace CleanArchitectureProject.Domain.Events.SongEvents;

public class SongPlayedEvent : BaseEvent
{
    public int SongId { get; }

    public SongPlayedEvent(int songId)
    {
        SongId = songId;
    }
}