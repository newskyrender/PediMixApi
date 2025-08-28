namespace PediMix.Domain.Enums;

public enum UserRole
{
    Audience = 1,
    Singer = 2,
    Venue = 3,
    Admin = 4
}

public enum Gender
{
    Male = 1,
    Female = 2,
    Other = 3,
    PreferNotToSay = 4
}

public enum EventCategory
{
    Show = 1,
    Festival = 2,
    Concert = 3,
    Karaoke = 4,
    OpenMic = 5,
    Competition = 6,
    Workshop = 7,
    Masterclass = 8,
    LiveStream = 9,
    Other = 10
}

public enum EventStatus
{
    Draft = 1,
    Published = 2,
    Live = 3,
    SoldOut = 4,
    Cancelled = 5,
    Postponed = 6,
    Completed = 7
}

public enum EventVisibility
{
    Public = 1,
    Private = 2,
    Unlisted = 3
}

public enum VenueType
{
    Club = 1,
    Bar = 2,
    Theater = 3,
    Arena = 4,
    Stadium = 5,
    Outdoor = 6,
    Private = 7,
    Online = 8,
    Other = 9
}

public enum SongRequestStatus
{
    Pending = 1,
    Accepted = 2,
    Declined = 3,
    Played = 4
}

public enum SongDifficulty
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}

public enum NotificationType
{
    EventReminder = 1,
    SongRequest = 2,
    EventUpdate = 3,
    NewFollower = 4,
    System = 5
}
