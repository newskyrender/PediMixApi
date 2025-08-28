using PediMix.Domain.Enums;

namespace PediMix.Application.DTOs;

public class SongDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public GenreDto Genre { get; set; } = new();
    public string Duration { get; set; } = string.Empty;
    public SongDifficulty Difficulty { get; set; }
    public string? Key { get; set; }
    public bool HasLyrics { get; set; }
    public string? Lyrics { get; set; }
    public string? Notes { get; set; }
    public int Year { get; set; }
    public bool IsPopular { get; set; }
}

public class CreateSongDto
{
    public string Title { get; set; } = string.Empty;
    public string Artist { get; set; } = string.Empty;
    public Guid GenreId { get; set; }
    public string Duration { get; set; } = string.Empty;
    public SongDifficulty Difficulty { get; set; } = SongDifficulty.Easy;
    public string? Key { get; set; }
    public bool HasLyrics { get; set; } = false;
    public string? Lyrics { get; set; }
    public string? Notes { get; set; }
    public int Year { get; set; }
    public bool IsPopular { get; set; } = false;
}

public class UpdateSongDto
{
    public string? Title { get; set; }
    public string? Artist { get; set; }
    public Guid? GenreId { get; set; }
    public string? Duration { get; set; }
    public SongDifficulty? Difficulty { get; set; }
    public string? Key { get; set; }
    public bool? HasLyrics { get; set; }
    public string? Lyrics { get; set; }
    public string? Notes { get; set; }
    public int? Year { get; set; }
    public bool? IsPopular { get; set; }
}

public class RepertoireDto
{
    public Guid Id { get; set; }
    public Guid ArtistProfileId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
    public List<SongDto> Songs { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}

public class CreateRepertoireDto
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = false;
    public List<Guid> SongIds { get; set; } = new();
}

public class UpdateRepertoireDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }
}

public class AddSongsToRepertoireDto
{
    public List<Guid> SongIds { get; set; } = new();
}

public class SongRequestDto
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public SongDto Song { get; set; } = new();
    public UserDto RequestedBy { get; set; } = new();
    public SongRequestStatus Status { get; set; }
    public string? Message { get; set; }
    public int Votes { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? PlayedAt { get; set; }
}

public class CreateSongRequestDto
{
    public Guid EventId { get; set; }
    public Guid SongId { get; set; }
    public string? Message { get; set; }
}

public class UpdateSongRequestStatusDto
{
    public SongRequestStatus Status { get; set; }
}

public class GenreDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Color { get; set; } = "#000000";
    public string? Description { get; set; }
}
