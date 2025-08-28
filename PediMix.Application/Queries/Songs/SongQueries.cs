using MediatR;
using PediMix.Application.DTOs;

namespace PediMix.Application.Queries.Songs;

public class GetSongByIdQuery : IRequest<SongDto?>
{
    public Guid Id { get; set; }
}

public class GetAllSongsQuery : IRequest<List<SongDto>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class SearchSongsQuery : IRequest<List<SongDto>>
{
    public string Query { get; set; } = string.Empty;
    public Guid? GenreId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 25;
}

public class GetPopularSongsQuery : IRequest<List<SongDto>>
{
    public int Count { get; set; } = 25;
}

public class GetSongsByGenreQuery : IRequest<List<SongDto>>
{
    public Guid GenreId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetSongsByArtistQuery : IRequest<List<SongDto>>
{
    public string Artist { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetRepertoireByIdQuery : IRequest<RepertoireDto?>
{
    public Guid Id { get; set; }
}

public class GetRepertoiresByArtistQuery : IRequest<List<RepertoireDto>>
{
    public Guid ArtistProfileId { get; set; }
}

public class GetActiveRepertoiresByArtistQuery : IRequest<List<RepertoireDto>>
{
    public Guid ArtistProfileId { get; set; }
}

public class GetSongRequestsByEventQuery : IRequest<List<SongRequestDto>>
{
    public Guid EventId { get; set; }
}

public class GetPendingSongRequestsByEventQuery : IRequest<List<SongRequestDto>>
{
    public Guid EventId { get; set; }
}

public class GetSongRequestsByUserQuery : IRequest<List<SongRequestDto>>
{
    public Guid UserId { get; set; }
}
