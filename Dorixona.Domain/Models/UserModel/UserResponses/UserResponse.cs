using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.UsrModel.UserResponses;
public class UserResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string MiddleName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public Role Role { get; set; }
    public Gender? Gender { get; set; }
    public string AccessToken { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
    public DateTime TokenExpiresAt { get; set; }
}
