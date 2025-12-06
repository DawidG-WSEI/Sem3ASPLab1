using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Exceptions.PlaylistExceptions;

public class PlaylistNotFoundException : Exception 
{ 
    public PlaylistNotFoundException(int id) : base($"Playlist with id {id} was not found.") { } 
}

