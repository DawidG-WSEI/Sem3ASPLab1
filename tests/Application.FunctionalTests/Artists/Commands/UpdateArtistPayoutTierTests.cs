using CleanArchitecture.Application.Artists.Commands.CreateArtist;
using CleanArchitecture.Application.Artists.Commands.UpdateArtistPayoutTier;
using CleanArchitecture.Domain.Entities;
using Ardalis.GuardClauses;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CleanArchitecture.Application.FunctionalTests.Artists.Commands;

using static Testing;

public class UpdateArtistPayoutTierTests : BaseTestFixture
{
    [Test]
    public async Task ShouldThrowIfArtistNotFound()
    {
        var command = new UpdateArtistPayoutTierCommand
        {
            ArtistId = 9999,
            PayoutTier = "Gold"
        };

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldUpdateArtistPayoutTier()
    {
        var artistId = await SendAsync(new CreateArtistCommand
        {
            Name = "Payout Artist",
            Username = "payoutartist",
            Email = "payoutartist@example.com",
            Bio = "Bio",
            PayoutTier = "Bronze",
            Password = "ArtistTest123!"
        });

        var updateCommand = new UpdateArtistPayoutTierCommand
        {
            ArtistId = artistId,
            PayoutTier = "Gold"
        };

        await SendAsync(updateCommand);

        var artist = await FindAsync<Artist>(artistId);

        artist.Should().NotBeNull();
        artist!.PayoutTier.Name.Should().Be("Gold");
    }
}