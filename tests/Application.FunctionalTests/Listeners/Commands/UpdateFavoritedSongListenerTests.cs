using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Listeners.Commands.UpdateFavoritedSongListener;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Exceptions.ListenerExceptions;
using CleanArchitecture.Domain.Exceptions.SongExceptions;
using CleanArchitecture.Domain.Events.ListenerEvents;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CleanArchitecture.Application.FunctionalTests.Listeners.Commands;

public class UpdateFavoritedSongListenerCommandHandlerTests
{
    private Mock<IApplicationDbContext> _contextMock;
    private UpdateFavoritedSongListenerCommandHandler _handler;
    private Listener _listener;
    private Song _song;

    [SetUp]
    public void SetUp()
    {
        _contextMock = new Mock<IApplicationDbContext>();
        _handler = new UpdateFavoritedSongListenerCommandHandler(_contextMock.Object);
        _listener = new Listener { Id = 1, FavouriteSongs = new List<Song>() };
        _song = new Song { Id = 2 };
    }

    [Test]
    public void ShouldThrowListenerNotFoundException_WhenListenerDoesNotExist()
    {
        _contextMock.Setup(x => x.Listeners.FindAsync(new object[] { 1 }, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Listener)null!);

        var command = new UpdateFavoritedSongListenerCommand(1, 2, true);
        var act = async () => await _handler.Handle(command, CancellationToken.None);
        act.Should().ThrowAsync<ListenerNotFoundException>();
    }

    [Test]
    public void ShouldThrowSongNotFoundException_WhenSongDoesNotExist()
    {
        _contextMock.Setup(x => x.Listeners.FindAsync(new object[] { 1 }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_listener);
        _contextMock.Setup(x => x.Songs.FindAsync(new object[] { 2 }, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Song)null!);

        var command = new UpdateFavoritedSongListenerCommand(1, 2, true);
        var act = async () => await _handler.Handle(command, CancellationToken.None);
        act.Should().ThrowAsync<SongNotFoundException>();
    }

    [Test]
    public async Task ShouldAddSongToFavourites_WhenIsFavoritedIsTrueAndNotAlreadyFavorited()
    {
        _contextMock.Setup(x => x.Listeners.FindAsync(new object[] { 1 }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_listener);
        _contextMock.Setup(x => x.Songs.FindAsync(new object[] { 2 }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_song);
        _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var command = new UpdateFavoritedSongListenerCommand(1, 2, true);
        await _handler.Handle(command, CancellationToken.None);

        _listener.FavouriteSongs.Should().Contain(_song);
    }

    [Test]
    public async Task ShouldRemoveSongFromFavourites_WhenIsFavoritedIsFalseAndSongIsFavorited()
    {
        _listener.FavouriteSongs.Add(_song);
        _contextMock.Setup(x => x.Listeners.FindAsync(new object[] { 1 }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_listener);
        _contextMock.Setup(x => x.Songs.FindAsync(new object[] { 2 }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_song);
        _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var command = new UpdateFavoritedSongListenerCommand(1, 2, false);
        await _handler.Handle(command, CancellationToken.None);

        _listener.FavouriteSongs.Should().NotContain(_song);
    }

    [Test]
    public async Task ShouldNotAddSongTwice_WhenAlreadyFavorited()
    {
        _listener.FavouriteSongs.Add(_song);
        _contextMock.Setup(x => x.Listeners.FindAsync(new object[] { 1 }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_listener);
        _contextMock.Setup(x => x.Songs.FindAsync(new object[] { 2 }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(_song);
        _contextMock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

        var command = new UpdateFavoritedSongListenerCommand(1, 2, true);
        await _handler.Handle(command, CancellationToken.None);

        _listener.FavouriteSongs.Should().HaveCount(1);
    }
}
