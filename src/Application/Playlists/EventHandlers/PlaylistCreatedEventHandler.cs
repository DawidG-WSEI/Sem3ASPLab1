using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Events.PlaylistEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Playlists.EventHandlers;

public class PlaylistCreatedEventHandler : INotificationHandler<PlaylistCreatedEvent>
{
    private readonly ILogger<PlaylistCreatedEventHandler> _logger;
    public PlaylistCreatedEventHandler(ILogger<PlaylistCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(PlaylistCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Playlist {PlaylistId} event: {EventType}", notification.EntityId, notification.EventType);
        return Task.CompletedTask;
    }
}
