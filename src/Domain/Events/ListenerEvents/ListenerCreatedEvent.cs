﻿using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.ListenerEvents;

public class ListenerCreatedEvent : EntityEvent<Listener>
{
    public ListenerCreatedEvent(Listener listener)
        : base(listener, EntityEventType.Created)
    {
    }
}