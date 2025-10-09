using CleanArchitecture.Application.Artists.Commands.CreateArtist;
using CleanArchitecture.Application.Artists.Commands.DeleteArtist;
using CleanArchitecture.Domain.Entities;
using Ardalis.GuardClauses;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CleanArchitecture.Application.FunctionalTests.Artists.Commands;

using static Testing;

public class DeleteArtistTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidArtistId()
    {
        var command = new DeleteArtistCommand(9999);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteArtist()
    {
        var createCommand = new CreateArtistCommand
        {
            Name = "Artist To Delete",
            Username = "artistdelete",
            Email = "artistdelete@example.com",
            Bio = "Test bio",
            PayoutTier = "Gold",
            Password = "ArtistDelete123!"
        };

        var artistId = await SendAsync(createCommand);

        await SendAsync(new DeleteArtistCommand(artistId));

        var artist = await FindAsync<Artist>(artistId);

        artist.Should().BeNull();
    }
}