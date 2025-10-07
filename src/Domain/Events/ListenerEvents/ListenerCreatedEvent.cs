﻿using FCleanArchitectureProjectDomain.Common;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.Events.ListenerEvents;

public class ListenerCreatedEvent : EntityEvent<Listener>
{
    public ListenerCreatedEvent(Listener listener)
        : base(listener, EntityEventType.Created)
    {
    }
}