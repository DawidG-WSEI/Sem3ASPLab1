using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CleanArchitecture.Application.Playlists.Commands.CreatePlaylist;

public class CreatePlaylistCommandValidator : AbstractValidator<CreatePlaylistCommand>
{
    public CreatePlaylistCommandValidator()
    {
        RuleFor(v => v.Title).NotEmpty().MaximumLength(200);
        RuleFor(v => v.ListenerId)
       .GreaterThan(0);
    }
}
