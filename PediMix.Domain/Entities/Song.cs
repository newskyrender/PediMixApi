using PediMix.Domain.Common;
using PediMix.Domain.Enums;

namespace PediMix.Domain.Entities;

public class Song : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public Guid GenreId { get; set; }
    public string Duration { get; set; } = string.Empty; // Format: "03:45"
    public SongDifficulty Difficulty { get; set; } = SongDifficulty.Easy;
    public string? Key { get; set; } // Musical key (C, D, Em, etc.)
    public bool HasLyrics { get; set; } = false;
    public string? Lyrics { get; set; }
    public string? Notes { get; set; }
    public int Year { get; set; }
    public bool IsPopular { get; set; } = false;

    // Navigation properties
    public virtual Genre Genre { get; set; } = null!;
    public virtual ICollection<RepertoireSong> RepertoireSongs { get; set; } = new List<RepertoireSong>();
    public virtual ICollection<SongRequest> SongRequests { get; set; } = new List<SongRequest>();
}

public class Repertoire : BaseEntity
{
    public Guid ArtistProfileId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = false;

    // Navigation properties
    public virtual ArtistProfile ArtistProfile { get; set; } = null!;
    public virtual ICollection<RepertoireSong> RepertoireSongs { get; set; } = new List<RepertoireSong>();
}

public class RepertoireSong : BaseEntity
{
    public Guid RepertoireId { get; set; }
    public Guid SongId { get; set; }
    public int Order { get; set; } = 0;

    // Navigation properties
    public virtual Repertoire Repertoire { get; set; } = null!;
    public virtual Song Song { get; set; } = null!;
}

public class SongRequest : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid SongId { get; set; }
    public Guid RequestedById { get; set; }
    public SongRequestStatus Status { get; set; } = SongRequestStatus.Pending;
    public string? Message { get; set; }
    public int Votes { get; set; } = 0;
    public DateTime? PlayedAt { get; set; }

    // Navigation properties
    public virtual Event Event { get; set; } = null!;
    public virtual Song Song { get; set; } = null!;
    public virtual User RequestedBy { get; set; } = null!;
}
