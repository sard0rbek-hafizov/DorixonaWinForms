using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.AuthModel.Entities;

// Har bir foydalanuvchi uchun refresh tokenlar tarixi.
// Token rotation, xavfsizlik va sessiyalarni boshqarish uchun kerak.
public class RefreshToken : Entity
{
    // FK: Refresh token kimga tegishli
    public Guid UserId { get; private set; }

    // Token qiymati
    public string Token { get; private set; } = default!;

    // Token amal qilish muddati
    public DateTime ExpiresAt { get; private set; }

    // Token yaratilgan vaqt
    public DateTime CreatedAt { get; private set; }

    // IP manzili va qurilma nomi (audit uchun)
    public string IpAddress { get; private set; } = string.Empty;
    public string Device { get; private set; } = string.Empty;

    // Token holati (Active, Consumed, Revoked)
    public TokenStatus Status { get; private set; } = TokenStatus.Active;

    // Token bekor qilingan vaqt (null bo'lishi mumkin)
    public DateTime? RevokedAt { get; private set; }
    public string DeviceId { get; private set; } = string.Empty;

    // EF Core uchun parameterless konstruktor
    private RefreshToken() { }

    // Refresh token yaratish konstruktori
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
        RevokedAt = null;
    }

    // Token muddati tugaganini tekshiradi
    public bool IsExpired() => DateTime.UtcNow >= ExpiresAt;

    // Tokenni bekor qiladi (logout, xavfsizlik sabablari)
    public void Revoke()
    {
        if (Status == TokenStatus.Revoked) return;
        Status = TokenStatus.Revoked;
        RevokedAt = DateTime.UtcNow;
    }

    // Tokenni foydalangan deb belgilash (1 marta ishlatilgan refresh token)
    public void MarkAsUsed()
    {
        if (Status != TokenStatus.Active) return;
        Status = TokenStatus.Consumed;
    }
}
