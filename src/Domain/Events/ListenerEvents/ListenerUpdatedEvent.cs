using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.ListenerEvents;

public class ListenerUpdatedEvent : EntityEvent<Listener>
{
    public ListenerUpdatedEvent(Listener listener)
        : base(listener, EntityEventType.Updated)
    {
    }
}