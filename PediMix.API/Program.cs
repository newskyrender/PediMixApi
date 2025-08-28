using Microsoft.EntityFrameworkCore;
using PediMix.Infrastructure.Data;
using PediMix.Application.Interfaces;
using PediMix.Infrastructure.Repositories;
using MediatR;
using PediMix.Application.Handlers.CommandHandlers;
using PediMix.Application.Handlers.QueryHandlers;
using PediMix.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PediMixDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

// Repository Pattern
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IArtistProfileRepository, ArtistProfileRepository>();
builder.Services.AddScoped<IVenueProfileRepository, VenueProfileRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();
builder.Services.AddScoped<IRepertoireRepository, RepertoireRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ISongRequestRepository, SongRequestRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

// MediatR
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(GetUserByIdQueryHandler).Assembly);
});

// AutoMapper
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<UserMappingProfile>();
    cfg.AddProfile<ProfileMappingProfile>();
    cfg.AddProfile<SongMappingProfile>();
    cfg.AddProfile<EventMappingProfile>();
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PediMix API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
