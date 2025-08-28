using PediMix.Domain.Enums;

namespace PediMix.Application.DTOs;

public class ArtistProfileDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string StageName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
    public int Followers { get; set; }
    public int TotalEvents { get; set; }
    public decimal Rating { get; set; }
    public string? InstagramUrl { get; set; }
    public string? YoutubeUrl { get; set; }
    public string? SpotifyUrl { get; set; }
    public string? SoundcloudUrl { get; set; }
    public string? TiktokUrl { get; set; }
    public List<GenreDto> Genres { get; set; } = new();
    public List<RepertoireDto> Repertoires { get; set; } = new();
}

public class CreateArtistProfileDto
{
    public string StageName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? InstagramUrl { get; set; }
    public string? YoutubeUrl { get; set; }
    public string? SpotifyUrl { get; set; }
    public string? SoundcloudUrl { get; set; }
    public string? TiktokUrl { get; set; }
    public List<Guid> GenreIds { get; set; } = new();
}

public class UpdateArtistProfileDto
{
    public string? StageName { get; set; }
    public string? Description { get; set; }
    public string? InstagramUrl { get; set; }
    public string? YoutubeUrl { get; set; }
    public string? SpotifyUrl { get; set; }
    public string? SoundcloudUrl { get; set; }
    public string? TiktokUrl { get; set; }
    public List<Guid>? GenreIds { get; set; }
}

public class VenueProfileDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public VenueType Type { get; set; }
    public bool IsVerified { get; set; }
    public decimal Rating { get; set; }
    public int TotalEvents { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public VenueAddressDto? VenueAddress { get; set; }
    public List<AmenityDto> Amenities { get; set; } = new();
}

public class CreateVenueProfileDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public VenueType Type { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public VenueAddressDto? VenueAddress { get; set; }
    public List<Guid> AmenityIds { get; set; } = new();
}

public class VenueAddressDto
{
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string? Complement { get; set; }
    public string Neighborhood { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Country { get; set; } = "Brasil";
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
}

public class AmenityDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string? Description { get; set; }
}
