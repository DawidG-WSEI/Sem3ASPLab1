using FluentValidation;

namespace CleanArchitecture.Application.Listeners.Queries.GetListenerByUsername;

public class GetListenerByUsernameQueryValidator : AbstractValidator<GetListenerByUsernameQuery>
{
    public GetListenerByUsernameQueryValidator()
    {
        RuleFor(v => v.Username)
            .NotEmpty()
            .WithMessage("Username must not be empty.");
    }
}