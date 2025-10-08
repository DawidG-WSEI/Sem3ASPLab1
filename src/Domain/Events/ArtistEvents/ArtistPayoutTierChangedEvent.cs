using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Events.ArtistEvents;

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