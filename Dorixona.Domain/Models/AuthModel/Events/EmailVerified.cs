namespace Dorixona.Domain.Models.AuthModel.Events;

public class EmailVerified
{
    public Guid UserId { get; }
    public DateTime VerifiedAt { get; }

    public EmailVerified(Guid userId, DateTime verifiedAt)
    {
        UserId = userId;
        VerifiedAt = verifiedAt;
    }
}