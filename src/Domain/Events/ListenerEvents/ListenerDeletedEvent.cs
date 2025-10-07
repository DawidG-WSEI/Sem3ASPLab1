using CleanArchitectureProject.Domain.Common;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.Events.ListenerEvents;

public class ListenerDeletedEvent : EntityEvent<Listener>
{
    public ListenerDeletedEvent(Listener listener)
        : base(listener, EntityEventType.Deleted)
    {
    }
}