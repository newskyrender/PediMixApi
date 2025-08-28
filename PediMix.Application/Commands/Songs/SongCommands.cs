using MediatR;
using PediMix.Application.DTOs;
using PediMix.Domain.Enums;

namespace PediMix.Application.Commands.Songs;

public class CreateSongCommand : IRequest<SongDto>
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

public class UpdateSongCommand : IRequest<SongDto>
{
    public Guid Id { get; set; }
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

public class DeleteSongCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class CreateRepertoireCommand : IRequest<RepertoireDto>
{
    public Guid ArtistProfileId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public bool IsActive { get; set; } = false;
    public List<Guid> SongIds { get; set; } = new();
}

public class UpdateRepertoireCommand : IRequest<RepertoireDto>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsActive { get; set; }
}

public class AddSongsToRepertoireCommand : IRequest<RepertoireDto>
{
    public Guid RepertoireId { get; set; }
    public List<Guid> SongIds { get; set; } = new();
}

public class RemoveSongFromRepertoireCommand : IRequest<bool>
{
    public Guid RepertoireId { get; set; }
    public Guid SongId { get; set; }
}

public class DeleteRepertoireCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

public class CreateSongRequestCommand : IRequest<SongRequestDto>
{
    public Guid EventId { get; set; }
    public Guid SongId { get; set; }
    public Guid RequestedById { get; set; }
    public string? Message { get; set; }
}

public class UpdateSongRequestStatusCommand : IRequest<SongRequestDto>
{
    public Guid Id { get; set; }
    public SongRequestStatus Status { get; set; }
}
