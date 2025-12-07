using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Events.PlaylistEvents;

public class PlaylistCreatedEvent : EntityEvent<Playlist> 
{ 
    public PlaylistCreatedEvent(Playlist playlist) : base(playlist, EntityEventType.Created) { } 
}

