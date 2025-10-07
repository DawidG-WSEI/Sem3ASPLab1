using CleanArchitectureProject.Domain.Common;
using CleanArchitectureProject.Domain.Entities;
using CleanArchitectureProject.Domain.ValueObjects;

namespace CleanArchitectureProject.Domain.Events.ArtistEvents;

public class ArtistPayoutTierChangedEvent : BaseEvent
{
    public Artist Artist { get; }
    public PayoutTier OldPayoutTier { get; }
    public PayoutTier NewPayoutTier { get; }

    public ArtistPayoutTierChangedEvent(Artist artist, PayoutTier oldPayoutTier, PayoutTier newPayoutTier)
    {
        Artist = artist;
        OldPayoutTier = oldPayoutTier;
        NewPayoutTier = newPayoutTier;
    }
}