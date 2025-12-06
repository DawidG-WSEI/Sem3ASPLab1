using CleanArchitecture.Application.Playlists.Commands.CreatePlaylist;
using CleanArchitecture.Application.Playlists.Commands.DeletePlaylist;
using CleanArchitecture.Application.Playlists.Commands.UpdatePlaylist;
using CleanArchitecture.Application.Playlists.Queries;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Web.Endpoints;

public class Playlists : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var group = app.MapGroup(this).RequireAuthorization();
        group.MapPost("/", CreatePlaylist);
        group.MapPut(UpdatePlaylist, "{id}");
        group.MapDelete(DeletePlaylist, "{id}");
        group.MapGet(GetPlaylistById, "{id}");
        group.MapGet(GetPlaylistsWithPagination);
    }

    public Task<int> CreatePlaylist(ISender sender, CreatePlaylistCommand command)
        => sender.Send(command);

    public async Task<IResult> UpdatePlaylist(ISender sender, int id, UpdatePlaylistCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeletePlaylist(ISender sender, int id)
    {
        await sender.Send(new DeletePlaylistCommand(id));
        return Results.NoContent();
    }

    public async Task<PlaylistDto?> GetPlaylistById(ISender sender, int id)
        => await sender.Send(new GetPlaylistByIdQuery(id));

    public async Task<PaginatedList<PlaylistDto>> GetPlaylistsWithPagination(ISender sender, [AsParameters] GetPlaylistsWithPaginationQuery query)
        => await sender.Send(query);
}
