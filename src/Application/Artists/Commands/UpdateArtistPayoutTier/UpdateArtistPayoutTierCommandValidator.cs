using FluentValidation;

namespace CleanArchitecture.Application.Artists.Commands.UpdateArtistPayoutTier;

public class UpdateArtistPayoutTierCommandValidator : AbstractValidator<UpdateArtistPayoutTierCommand>
{
    public UpdateArtistPayoutTierCommandValidator()
    {
        RuleFor(v => v.ArtistId)
            .GreaterThan(0);

        RuleFor(v => v.PayoutTier)
            .NotEmpty()
            .WithMessage("PayoutTier is required.");
    }
}