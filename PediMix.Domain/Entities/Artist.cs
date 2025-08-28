using PediMix.Domain.Common;

namespace PediMix.Domain.Entities;

public class ArtistProfile : BaseEntity
{
    public Guid UserId { get; set; }
    public string StageName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsVerified { get; set; } = false;
    public int Followers { get; set; } = 0;
    public int TotalEvents { get; set; } = 0;
    public decimal Rating { get; set; } = 0;

    // Social Links
    public string? InstagramUrl { get; set; }
    public string? YoutubeUrl { get; set; }
    public string? SpotifyUrl { get; set; }
    public string? SoundcloudUrl { get; set; }
    public string? TiktokUrl { get; set; }

    // Navigation properties
    public virtual User User { get; set; } = null!;
    public virtual ICollection<ArtistGenre> ArtistGenres { get; set; } = new List<ArtistGenre>();
    public virtual ICollection<Repertoire> Repertoires { get; set; } = new List<Repertoire>();
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}

public class Genre : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = "#000000";
    public string? Description { get; set; }

    // Navigation properties
    public virtual ICollection<ArtistGenre> ArtistGenres { get; set; } = new List<ArtistGenre>();
    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}

public class ArtistGenre : BaseEntity
{
    public Guid ArtistProfileId { get; set; }
    public Guid GenreId { get; set; }

    // Navigation properties
    public virtual ArtistProfile ArtistProfile { get; set; } = null!;
    public virtual Genre Genre { get; set; } = null!;
}
