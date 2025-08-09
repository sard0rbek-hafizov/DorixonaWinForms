using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;

namespace Dorixona.Infrastructure.Authentication.RefreshTokens;
public class RefreshToken : Entity
{
    public Guid UserId { get; private set; }
    public string Token { get; private set; } = default!;
    public DateTime ExpiresAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string IpAddress { get; private set; } = string.Empty;
    public string Device { get; private set; } = string.Empty;
    public string DeviceId { get; private set; } = string.Empty;
    public TokenStatus Status { get; private set; } = TokenStatus.Active;
    public DateTime? RevokedAt { get; private set; }

    private RefreshToken() { }

    public RefreshToken(Guid userId, string token, DateTime expiresAt, string ipAddress, string device, string deviceId)
    {
        UserId = userId;
        Token = token;
        ExpiresAt = expiresAt;
        IpAddress = ipAddress;
        Device = device;
        DeviceId = deviceId;
        CreatedAt = DateTime.UtcNow;
        Status = TokenStatus.Active;
    }

    public bool IsExpired() => DateTime.UtcNow >= ExpiresAt;

    public void Revoke()
    {
        if (Status == TokenStatus.Revoked) return;
        Status = TokenStatus.Revoked;
        RevokedAt = DateTime.UtcNow;
    }

    public void MarkAsUsed()
    {
        if (Status != TokenStatus.Active) return;
        Status = TokenStatus.Consumed;
    }
}