using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.AuthModel.Events;

public sealed class UserRegistered
{
    public Guid UserId { get; init; }
    public string Email { get; init; } = default!;
    public Role Role { get; init; }
    public DateTime RegisteredAt { get; init; }

    public UserRegistered(Guid userId, string email, Role role, DateTime registeredAt)
    {
        UserId = userId;
        Email = email;
        Role = role;
        RegisteredAt = registeredAt;
    }
}
