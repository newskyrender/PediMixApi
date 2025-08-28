using MediatR;
using PediMix.Application.DTOs;

namespace PediMix.Application.Queries.Users;

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public Guid Id { get; set; }
}

public class GetUserByEmailQuery : IRequest<UserDto?>
{
    public string Email { get; set; } = string.Empty;
}

public class GetUserByUsernameQuery : IRequest<UserDto?>
{
    public string Username { get; set; } = string.Empty;
}

public class GetUserWithProfilesQuery : IRequest<UserDto?>
{
    public Guid Id { get; set; }
}

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
