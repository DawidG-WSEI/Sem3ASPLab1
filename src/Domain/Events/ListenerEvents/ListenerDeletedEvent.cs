using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.ListenerEvents;

public class ListenerDeletedEvent : EntityEvent<Listener>
{
    public ListenerDeletedEvent(Listener listener)
        : base(listener, EntityEventType.Deleted)
    {
    }
}