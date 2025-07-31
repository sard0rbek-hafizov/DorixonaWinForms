using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.UsrModel.UserDTO;

public class UserDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string MiddleName { get; set; } = default!;
    public string FullName => $"{FirstName} {LastName} {MiddleName}";
    public string Email { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public Gender? Gender { get; set; }
    public Role Role { get; set; }
    public UserStatus Status { get; set; }
    public string? ProfileImage { get; set; }
    public DateTime? LastLoginAt { get; set; }
}