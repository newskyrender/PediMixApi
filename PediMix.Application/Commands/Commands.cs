using MediatR;
using PediMix.Application.DTOs;
using PediMix.Domain.Enums;

namespace PediMix.Application.Commands;

public record CreateUserCommand(
    string Username,
    string Email,
    string FirstName,
    string LastName,
    string PasswordHash,
    string? PhoneNumber,
    UserRole Role
) : IRequest<UserDto>;

public record UpdateUserCommand(
    Guid Id,
    string Username,
    string Email,
    string FirstName,
    string LastName,
    string? PhoneNumber
) : IRequest<UserDto>;

public record CreateSongCommand(
    string Title,
    string Artist,
    string? Album,
    int? Duration,
    Guid GenreId,
    string? Key,
    int? Tempo,
    int? Year,
    string? SpotifyId,
    string? YouTubeId
) : IRequest<SongDto>;

public record CreateEventCommand(
    string Name,
    string? Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    Guid ArtistProfileId,
    Guid VenueProfileId,
    decimal? Price,
    int? MaxCapacity,
    bool IsPublic,
    bool AcceptSongRequests
) : IRequest<EventDto>;

public record CreateSongRequestCommand(
    Guid EventId,
    Guid SongId,
    Guid UserId,
    string? Message
) : IRequest<SongRequestDto>;
