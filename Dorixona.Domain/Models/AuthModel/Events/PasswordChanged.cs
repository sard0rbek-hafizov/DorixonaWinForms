namespace Dorixona.Domain.Models.AuthModel.Events;

public class PasswordChanged
{
    public Guid UserId { get; }
    public DateTime ChangedAt { get; }

    public PasswordChanged(Guid userId, DateTime changedAt)
    {
        UserId = userId;
        ChangedAt = changedAt;
    }
}