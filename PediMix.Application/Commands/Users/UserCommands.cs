using MediatR;
using PediMix.Application.DTOs;
using PediMix.Domain.Enums;

namespace PediMix.Application.Commands.Users;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}

public class UpdateUserCommand : IRequest<UserDto>
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Bio { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
}

public class CompleteUserProfileCommand : IRequest<UserDto>
{
    public Guid UserId { get; set; }
    public string? Cpf { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender? Gender { get; set; }
    public AddressDto? Address { get; set; }
    public string? Phone { get; set; }
    public string? Whatsapp { get; set; }
    public string? EmergencyContact { get; set; }
    public string? EmergencyPhone { get; set; }
}

public class DeleteUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}
