﻿using FCleanArchitectureProjectDomain.Common;
using CleanArchitectureProject.Domain.Entities;

namespace CleanArchitectureProject.Domain.Events.ArtistEvents
{
    public class ArtistCreatedEvent : EntityEvent<Artist>
    {
        public ArtistCreatedEvent(Artist artist)
            : base(artist, EntityEventType.Created)
        {
        }
    }
}