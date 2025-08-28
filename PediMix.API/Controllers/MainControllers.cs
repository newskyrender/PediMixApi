using MediatR;
using Microsoft.AspNetCore.Mvc;
using PediMix.Application.Commands;
using PediMix.Application.Queries;
using PediMix.Application.DTOs;

namespace PediMix.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetById(Guid id)
    {
        var query = new GetUserByIdQuery(id);
        var result = await _mediator.Send(query);
        
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult<UserDto>> GetByEmail(string email)
    {
        var query = new GetUserByEmailQuery(email);
        var result = await _mediator.Send(query);
        
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> Update(Guid id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.Id)
            return BadRequest("ID do usuário não confere.");

        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SongsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("genre/{genreId}")]
    public async Task<ActionResult<IEnumerable<SongDto>>> GetByGenre(Guid genreId)
    {
        var query = new GetSongsByGenreQuery(genreId);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<SongDto>>> Search([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return BadRequest("Query de busca é obrigatório.");

        var searchQuery = new SearchSongsQuery(query);
        var result = await _mediator.Send(searchQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<SongDto>> Create([FromBody] CreateSongCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetByGenre), new { genreId = result.Genre.Id }, result);
    }
}

[ApiController]
[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventDto>> GetById(Guid id)
    {
        var query = new GetEventByIdQuery(id);
        var result = await _mediator.Send(query);
        
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("upcoming")]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetUpcoming([FromQuery] int count = 10)
    {
        var query = new GetUpcomingEventsQuery(count);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("date-range")]
    public async Task<ActionResult<IEnumerable<EventDto>>> GetByDateRange(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        var query = new GetEventsByDateRangeQuery(startDate, endDate);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EventDto>> Create([FromBody] CreateEventCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }
}

[ApiController]
[Route("api/[controller]")]
public class SongRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SongRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("event/{eventId}")]
    public async Task<ActionResult<IEnumerable<SongRequestDto>>> GetByEvent(
        Guid eventId,
        [FromQuery] bool pendingOnly = false)
    {
        var query = new GetSongRequestsByEventQuery(eventId, pendingOnly);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<SongRequestDto>> Create([FromBody] CreateSongRequestCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetByEvent), new { eventId = result.EventId }, result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

[ApiController]
[Route("api/[controller]")]
public class RepertoiresController : ControllerBase
{
    private readonly IMediator _mediator;

    public RepertoiresController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}/songs")]
    public async Task<ActionResult<RepertoireDto>> GetWithSongs(Guid id)
    {
        var query = new GetRepertoireWithSongsQuery(id);
        var result = await _mediator.Send(query);
        
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("artist/{artistProfileId}")]
    public async Task<ActionResult<IEnumerable<RepertoireDto>>> GetByArtist(
        Guid artistProfileId,
        [FromQuery] bool activeOnly = false)
    {
        var query = new GetRepertoiresByArtistQuery(artistProfileId, activeOnly);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
