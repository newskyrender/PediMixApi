using MediatR;
using PediMix.Application.DTOs;

namespace PediMix.Application.Queries;

public record GetUserByIdQuery(Guid Id) : IRequest<UserDto?>;

public record GetUserByEmailQuery(string Email) : IRequest<UserDto?>;

public record GetSongsByGenreQuery(Guid GenreId) : IRequest<IEnumerable<SongDto>>;

public record SearchSongsQuery(string Query) : IRequest<IEnumerable<SongDto>>;

public record GetEventsByDateRangeQuery(DateTime StartDate, DateTime EndDate) : IRequest<IEnumerable<EventDto>>;

public record GetEventByIdQuery(Guid Id) : IRequest<EventDto?>;

public record GetUpcomingEventsQuery(int Count = 10) : IRequest<IEnumerable<EventDto>>;

public record GetSongRequestsByEventQuery(Guid EventId, bool PendingOnly = false) : IRequest<IEnumerable<SongRequestDto>>;

public record GetRepertoiresByArtistQuery(Guid ArtistProfileId, bool ActiveOnly = false) : IRequest<IEnumerable<RepertoireDto>>;

public record GetRepertoireWithSongsQuery(Guid Id) : IRequest<RepertoireDto?>;
