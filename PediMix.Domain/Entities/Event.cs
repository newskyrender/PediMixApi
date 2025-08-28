using PediMix.Domain.Common;
using PediMix.Domain.Enums;

namespace PediMix.Domain.Entities;

public class Event : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public EventCategory Category { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string Timezone { get; set; } = "America/Sao_Paulo";
    public EventStatus Status { get; set; } = EventStatus.Draft;
    public EventVisibility Visibility { get; set; } = EventVisibility.Public;
    public bool IsAgeRestricted { get; set; } = false;
    public int? MinimumAge { get; set; }
    public bool IsOnline { get; set; } = false;
    public string? StreamUrl { get; set; }
    public string? CoverImage { get; set; }
    public bool IsPaid { get; set; } = false;
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string Currency { get; set; } = "BRL";
    
    // Counters
    public int Likes { get; set; } = 0;
    public int Views { get; set; } = 0;
    public int Shares { get; set; } = 0;
    public int TotalCapacity { get; set; } = 0;
    public int AvailableTickets { get; set; } = 0;
    public int SoldTickets { get; set; } = 0;
    
    // Relationships
    public Guid CreatedById { get; set; }
    public Guid? ArtistProfileId { get; set; }
    public Guid? VenueProfileId { get; set; }
    public DateTime? PublishedAt { get; set; }

    // Navigation properties
    public virtual User CreatedBy { get; set; } = null!;
    public virtual ArtistProfile? ArtistProfile { get; set; }
    public virtual VenueProfile? VenueProfile { get; set; }
    public virtual ICollection<EventGenre> EventGenres { get; set; } = new List<EventGenre>();
    public virtual ICollection<EventUser> EventUsers { get; set; } = new List<EventUser>();
    public virtual ICollection<SongRequest> SongRequests { get; set; } = new List<SongRequest>();
    public virtual ICollection<EventTag> EventTags { get; set; } = new List<EventTag>();
}

public class EventGenre : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid GenreId { get; set; }

    // Navigation properties
    public virtual Event Event { get; set; } = null!;
    public virtual Genre Genre { get; set; } = null!;
}

public class EventUser : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public string InteractionType { get; set; } = string.Empty; // VIEW, LIKE, SAVE, ATTEND, INTERESTED
    public DateTime InteractionDate { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual Event Event { get; set; } = null!;
    public virtual User User { get; set; } = null!;
}

public class Tag : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = "#000000";

    // Navigation properties
    public virtual ICollection<EventTag> EventTags { get; set; } = new List<EventTag>();
}

public class EventTag : BaseEntity
{
    public Guid EventId { get; set; }
    public Guid TagId { get; set; }

    // Navigation properties
    public virtual Event Event { get; set; } = null!;
    public virtual Tag Tag { get; set; } = null!;
}
