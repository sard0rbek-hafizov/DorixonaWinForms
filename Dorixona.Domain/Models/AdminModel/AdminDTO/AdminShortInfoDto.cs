using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminShortInfoDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string FullName => $"{FirstName} {LastName}";

    public string Email { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public Role Role { get; set; }

    public UserStatus Status { get; set; }

    public Gender Gender { get; set; }

    public DateTime CreatedAt { get; set; }
}
