using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Playlists.Queries;

public class PlaylistDto 
{ 
    public int Id { get; set; } 
    public string Title { get; set; } = default!; 
    public int ListenerId { get; set; } 
    public int SongCount { get; set; } 
}

