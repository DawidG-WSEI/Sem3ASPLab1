namespace CleanArchitecture.Domain.Entities;

public class Playlist : BaseAuditableEntity
{
    public string Title { get; set; } = default!;
    public int ListenerId { get; set; }
    public Listener? Listener { get; set; }
    public ICollection<Song> Songs { get; set; } = new List<Song>();
}
