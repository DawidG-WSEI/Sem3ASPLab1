using System;

namespace CleanArchitecture.Domain.Exceptions.ArtistExceptions;

public class ArtistNotFoundException : Exception
{
    public ArtistNotFoundException(int artistId)
        : base($"Artist with ID {artistId} was not found.")
    {
    }
}