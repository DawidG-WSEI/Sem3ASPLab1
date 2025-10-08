﻿using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events.ArtistEvents
{
    public class ArtistCreatedEvent : EntityEvent<Artist>
    {
        public ArtistCreatedEvent(Artist artist)
            : base(artist, EntityEventType.Created)
        {
        }
    }
}