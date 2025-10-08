namespace CleanArchitecture.Domain.Entities;

public class Listener : UserAccount
{
    public ICollection<Song> FavouriteSongs { get; set; } = new List<Song>();
}