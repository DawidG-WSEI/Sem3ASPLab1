using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Events.PlaylistEvents;

public class PlaylistCreatedEvent : EntityEvent<Entities.Playlist> 
{ 
    public PlaylistCreatedEvent(Entities.Playlist playlist) : base(playlist, EntityEventType.Created) { } 
}

