using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace Dorixona.Domain.Models.UserModel.UserEntities;

public class User : BaseParams
{
    // Personal Info
    [Required, MaxLength(50)]
    public string FirstName { get; set; } = default!;

    [Required, MaxLength(50)]
    public string LastName { get; set; } = default!;

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    // Contact & Authentication
    [Required, EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    public string PasswordHash { get; set; } = default!;

    [Phone]
    public string? PhoneNumber { get; set; }

    // Optional
    public string? ProfileImageUrl { get; set; }
    public Gender? Gender { get; set; }

    // System Access & Security
    public Role Role { get; set; } = Role.Patient;
    public UserStatus Status { get; set; } = UserStatus.Active;
    public bool IsEmailConfirmed { get; set; } = false;
    public bool IsPhoneConfirmed { get; set; } = false;
    public bool IsTwoFactorEnabled { get; set; } = false;
    public DateTime? EmailVerifiedAt { get; private set; }

    public int AccessFailedCount { get; set; } = 0;
    public DateTime? LockoutEnd { get; set; }

    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAt { get; set; }

    // Soft Delete
    public bool IsDeleted { get; set; } = false;
    // Computed property
    public string FullName => $"{FirstName} {LastName} {MiddleName}";
    public User(string firstName, string lastName, string? middleName, string email, string password, string? phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Email = email;
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
        PhoneNumber = phoneNumber;
        RegisteredAt = DateTime.UtcNow;
    }
    public User() { }
}
