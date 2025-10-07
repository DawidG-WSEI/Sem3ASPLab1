using CleanArchitectureProject.Domain.Common;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.Events.ListenerEvents;

public class ListenerUpdatedEvent : EntityEvent<Listener>
{
    public ListenerUpdatedEvent(Listener listener)
        : base(listener, EntityEventType.Updated)
    {
    }
}