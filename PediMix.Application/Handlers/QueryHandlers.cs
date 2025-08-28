using AutoMapper;
using MediatR;
using PediMix.Application.Interfaces;
using PediMix.Application.Queries;
using PediMix.Application.DTOs;

namespace PediMix.Application.Handlers.QueryHandlers;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(request.Id);
        return user != null ? _mapper.Map<UserDto>(user) : null;
    }
}

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserByEmailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetByEmailAsync(request.Email);
        return user != null ? _mapper.Map<UserDto>(user) : null;
    }
}

public class GetSongsByGenreQueryHandler : IRequestHandler<GetSongsByGenreQuery, IEnumerable<SongDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSongsByGenreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SongDto>> Handle(GetSongsByGenreQuery request, CancellationToken cancellationToken)
    {
        var songs = await _unitOfWork.Songs.GetByGenreAsync(request.GenreId);
        return _mapper.Map<IEnumerable<SongDto>>(songs);
    }
}

public class SearchSongsQueryHandler : IRequestHandler<SearchSongsQuery, IEnumerable<SongDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SearchSongsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SongDto>> Handle(SearchSongsQuery request, CancellationToken cancellationToken)
    {
        var songs = await _unitOfWork.Songs.SearchAsync(request.Query);
        return _mapper.Map<IEnumerable<SongDto>>(songs);
    }
}

public class GetEventsByDateRangeQueryHandler : IRequestHandler<GetEventsByDateRangeQuery, IEnumerable<EventDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEventsByDateRangeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EventDto>> Handle(GetEventsByDateRangeQuery request, CancellationToken cancellationToken)
    {
        var events = await _unitOfWork.Events.GetByDateRangeAsync(request.StartDate, request.EndDate);
        return _mapper.Map<IEnumerable<EventDto>>(events);
    }
}

public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetEventByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EventDto?> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
    {
        var eventEntity = await _unitOfWork.Events.GetWithDetailsAsync(request.Id);
        return eventEntity != null ? _mapper.Map<EventDto>(eventEntity) : null;
    }
}

public class GetUpcomingEventsQueryHandler : IRequestHandler<GetUpcomingEventsQuery, IEnumerable<EventDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUpcomingEventsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EventDto>> Handle(GetUpcomingEventsQuery request, CancellationToken cancellationToken)
    {
        var events = await _unitOfWork.Events.GetUpcomingEventsAsync(request.Count);
        return _mapper.Map<IEnumerable<EventDto>>(events);
    }
}

public class GetSongRequestsByEventQueryHandler : IRequestHandler<GetSongRequestsByEventQuery, IEnumerable<SongRequestDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSongRequestsByEventQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SongRequestDto>> Handle(GetSongRequestsByEventQuery request, CancellationToken cancellationToken)
    {
        var songRequests = request.PendingOnly 
            ? await _unitOfWork.SongRequests.GetPendingByEventAsync(request.EventId)
            : await _unitOfWork.SongRequests.GetByEventAsync(request.EventId);
        
        return _mapper.Map<IEnumerable<SongRequestDto>>(songRequests);
    }
}

public class GetRepertoiresByArtistQueryHandler : IRequestHandler<GetRepertoiresByArtistQuery, IEnumerable<RepertoireDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRepertoiresByArtistQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RepertoireDto>> Handle(GetRepertoiresByArtistQuery request, CancellationToken cancellationToken)
    {
        var repertoires = request.ActiveOnly
            ? await _unitOfWork.Repertoires.GetActiveByArtistAsync(request.ArtistProfileId)
            : await _unitOfWork.Repertoires.GetByArtistAsync(request.ArtistProfileId);
        
        return _mapper.Map<IEnumerable<RepertoireDto>>(repertoires);
    }
}

public class GetRepertoireWithSongsQueryHandler : IRequestHandler<GetRepertoireWithSongsQuery, RepertoireDto?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRepertoireWithSongsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RepertoireDto?> Handle(GetRepertoireWithSongsQuery request, CancellationToken cancellationToken)
    {
        var repertoire = await _unitOfWork.Repertoires.GetWithSongsAsync(request.Id);
        return repertoire != null ? _mapper.Map<RepertoireDto>(repertoire) : null;
    }
}
