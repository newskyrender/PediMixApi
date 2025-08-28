using PediMix.Domain.Enums;

namespace PediMix.Application.DTOs;

public class EventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public EventCategory Category { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string Timezone { get; set; } = string.Empty;
    public EventStatus Status { get; set; }
    public EventVisibility Visibility { get; set; }
    public bool IsAgeRestricted { get; set; }
    public int? MinimumAge { get; set; }
    public bool IsOnline { get; set; }
    public string? StreamUrl { get; set; }
    public string? CoverImage { get; set; }
    public bool IsPaid { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string Currency { get; set; } = "BRL";
    public int Likes { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int TotalCapacity { get; set; }
    public int AvailableTickets { get; set; }
    public int SoldTickets { get; set; }
    public DateTime? PublishedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    
    // Navigation properties
    public UserDto CreatedBy { get; set; } = new();
    public ArtistProfileDto? ArtistProfile { get; set; }
    public VenueProfileDto? VenueProfile { get; set; }
    public List<GenreDto> Genres { get; set; } = new();
    public List<TagDto> Tags { get; set; } = new();
}

public class EventListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public EventCategory Category { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public EventStatus Status { get; set; }
    public string? CoverImage { get; set; }
    public bool IsPaid { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string Currency { get; set; } = "BRL";
    public int Likes { get; set; }
    public int AvailableTickets { get; set; }
    public string ArtistName { get; set; } = string.Empty;
    public string? ArtistAvatar { get; set; }
    public bool IsArtistVerified { get; set; }
    public string VenueName { get; set; } = string.Empty;
    public string VenueCity { get; set; } = string.Empty;
    public string VenueState { get; set; } = string.Empty;
    public bool IsLiked { get; set; }
    public bool IsSaved { get; set; }
}

public class CreateEventDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public EventCategory Category { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public string Timezone { get; set; } = "America/Sao_Paulo";
    public EventVisibility Visibility { get; set; } = EventVisibility.Public;
    public bool IsAgeRestricted { get; set; } = false;
    public int? MinimumAge { get; set; }
    public bool IsOnline { get; set; } = false;
    public string? StreamUrl { get; set; }
    public bool IsPaid { get; set; } = false;
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string Currency { get; set; } = "BRL";
    public int TotalCapacity { get; set; }
    public Guid? ArtistProfileId { get; set; }
    public Guid? VenueProfileId { get; set; }
    public List<Guid> GenreIds { get; set; } = new();
    public List<string> Tags { get; set; } = new();
}

public class UpdateEventDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public EventCategory? Category { get; set; }
    public DateTime? Date { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public EventStatus? Status { get; set; }
    public EventVisibility? Visibility { get; set; }
    public bool? IsAgeRestricted { get; set; }
    public int? MinimumAge { get; set; }
    public bool? IsOnline { get; set; }
    public string? StreamUrl { get; set; }
    public bool? IsPaid { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? TotalCapacity { get; set; }
    public List<Guid>? GenreIds { get; set; }
    public List<string>? Tags { get; set; }
}

public class EventSearchDto
{
    public string? Query { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public List<EventCategory>? Categories { get; set; }
    public List<Guid>? GenreIds { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool? IsFree { get; set; }
    public decimal? MaxPrice { get; set; }
    public EventStatus? Status { get; set; }
    public bool? IsOnline { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string SortBy { get; set; } = "Date";
    public string SortOrder { get; set; } = "asc";
}

public class TagDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = "#000000";
}
