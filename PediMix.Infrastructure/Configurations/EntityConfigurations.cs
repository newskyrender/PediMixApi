using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PediMix.Domain.Entities;

namespace PediMix.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(20);
        
        builder.Property(u => u.Bio)
            .HasMaxLength(1000);

        // Relationships
        builder.HasOne(u => u.Address)
            .WithOne(a => a.User)
            .HasForeignKey<Address>(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.Preferences)
            .WithOne(p => p.User)
            .HasForeignKey<UserPreferences>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.ArtistProfile)
            .WithOne(ap => ap.User)
            .HasForeignKey<ArtistProfile>(ap => ap.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(u => u.VenueProfile)
            .WithOne(vp => vp.User)
            .HasForeignKey<VenueProfile>(vp => vp.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class ArtistProfileConfiguration : IEntityTypeConfiguration<ArtistProfile>
{
    public void Configure(EntityTypeBuilder<ArtistProfile> builder)
    {
        builder.HasKey(ap => ap.Id);
        
        builder.Property(ap => ap.StageName)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(ap => ap.Description)
            .HasMaxLength(2000);
        
        builder.Property(ap => ap.Rating)
            .HasColumnType("decimal(3,2)");

        builder.Property(ap => ap.InstagramUrl)
            .HasMaxLength(500);
        
        builder.Property(ap => ap.YoutubeUrl)
            .HasMaxLength(500);
        
        builder.Property(ap => ap.SpotifyUrl)
            .HasMaxLength(500);
        
        builder.Property(ap => ap.SoundcloudUrl)
            .HasMaxLength(500);
        
        builder.Property(ap => ap.TiktokUrl)
            .HasMaxLength(500);
    }
}

public class VenueProfileConfiguration : IEntityTypeConfiguration<VenueProfile>
{
    public void Configure(EntityTypeBuilder<VenueProfile> builder)
    {
        builder.HasKey(vp => vp.Id);
        
        builder.Property(vp => vp.Name)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(vp => vp.Description)
            .HasMaxLength(2000);
        
        builder.Property(vp => vp.Rating)
            .HasColumnType("decimal(3,2)");

        builder.Property(vp => vp.Phone)
            .HasMaxLength(20);
        
        builder.Property(vp => vp.Email)
            .HasMaxLength(255);
        
        builder.Property(vp => vp.Website)
            .HasMaxLength(500);

        // Relationship with VenueAddress
        builder.HasOne(vp => vp.VenueAddress)
            .WithOne(va => va.VenueProfile)
            .HasForeignKey<VenueAddress>(va => va.VenueProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Title)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.Property(s => s.Artist)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(s => s.Duration)
            .HasMaxLength(10);
        
        builder.Property(s => s.Key)
            .HasMaxLength(10);
        
        builder.Property(s => s.Lyrics)
            .HasMaxLength(10000);
        
        builder.Property(s => s.Notes)
            .HasMaxLength(2000);

        // Relationship with Genre
        builder.HasOne(s => s.Genre)
            .WithMany(g => g.Songs)
            .HasForeignKey(s => s.GenreId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class RepertoireConfiguration : IEntityTypeConfiguration<Repertoire>
{
    public void Configure(EntityTypeBuilder<Repertoire> builder)
    {
        builder.HasKey(r => r.Id);
        
        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(r => r.Description)
            .HasMaxLength(1000);

        // Relationship with ArtistProfile
        builder.HasOne(r => r.ArtistProfile)
            .WithMany(ap => ap.Repertoires)
            .HasForeignKey(r => r.ArtistProfileId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(300);
        
        builder.Property(e => e.Description)
            .HasMaxLength(5000);
        
        builder.Property(e => e.Timezone)
            .HasMaxLength(50);
        
        builder.Property(e => e.StreamUrl)
            .HasMaxLength(500);
        
        builder.Property(e => e.CoverImage)
            .HasMaxLength(500);
        
        builder.Property(e => e.Currency)
            .HasMaxLength(3);

        builder.Property(e => e.MinPrice)
            .HasColumnType("decimal(10,2)");
        
        builder.Property(e => e.MaxPrice)
            .HasColumnType("decimal(10,2)");

        // Relationships
        builder.HasOne(e => e.CreatedBy)
            .WithMany(u => u.CreatedEvents)
            .HasForeignKey(e => e.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ArtistProfile)
            .WithMany(ap => ap.Events)
            .HasForeignKey(e => e.ArtistProfileId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.VenueProfile)
            .WithMany(vp => vp.Events)
            .HasForeignKey(e => e.VenueProfileId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}

public class SongRequestConfiguration : IEntityTypeConfiguration<SongRequest>
{
    public void Configure(EntityTypeBuilder<SongRequest> builder)
    {
        builder.HasKey(sr => sr.Id);
        
        builder.Property(sr => sr.Message)
            .HasMaxLength(500);

        // Relationships
        builder.HasOne(sr => sr.Event)
            .WithMany(e => e.SongRequests)
            .HasForeignKey(sr => sr.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sr => sr.Song)
            .WithMany(s => s.SongRequests)
            .HasForeignKey(sr => sr.SongId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(sr => sr.RequestedBy)
            .WithMany(u => u.SongRequests)
            .HasForeignKey(sr => sr.RequestedById)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(g => g.Id);
        
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(g => g.Color)
            .HasMaxLength(7);
        
        builder.Property(g => g.Description)
            .HasMaxLength(500);

        builder.HasIndex(g => g.Name)
            .IsUnique();
    }
}
