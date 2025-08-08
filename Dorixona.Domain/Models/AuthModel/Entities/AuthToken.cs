using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.AuthModel.Entities;

// Foydalanuvchiga tegishli JWT va Refresh tokenlarni ifodalaydi.
public class AuthToken : Entity
{
    // FK: Foydalanuvchi ID
    public Guid UserId { get; private set; }

    // Token qiymatlari
    public string AccessToken { get; private set; } = default!;
    public string RefreshToken { get; private set; } = default!;

    // Token amal qilish vaqtlari
    public DateTime AccessTokenExpiresAt { get; private set; }
    public DateTime RefreshTokenExpiresAt { get; private set; }

    // Token holati
    public TokenStatus Status { get; private set; } = TokenStatus.Active;

    // Qurilma va IP manzili
    public string Device { get; private set; } = string.Empty;
    public string IpAddress { get; private set; } = string.Empty;

    // EF Core uchun parameterless constructor
    private AuthToken() { }

    // Konstruktor: yangi token yaratish uchun
    public AuthToken(
        Guid userId,
        string accessToken,
        string refreshToken,
        DateTime accessTokenExpiresAt,
        DateTime refreshTokenExpiresAt,
        string device,
        string ipAddress)
    {
        UserId = userId;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        AccessTokenExpiresAt = accessTokenExpiresAt;
        RefreshTokenExpiresAt = refreshTokenExpiresAt;
        Device = device;
        IpAddress = ipAddress;
        Status = TokenStatus.Active;
    }

    // Token bekor qilinadi (logout yoki xavfsizlik sabablari bilan).
    public void Revoke()
    {
        if (Status == TokenStatus.Revoked) return;
        Status = TokenStatus.Revoked;
    }

    // Refresh token muddati tugaganligini tekshiradi.
    public bool IsRefreshTokenExpired() =>
        RefreshTokenExpiresAt <= DateTime.UtcNow;

    // Access token muddati tugaganligini tekshiradi.
    public bool IsAccessTokenExpired() =>
        AccessTokenExpiresAt <= DateTime.UtcNow;

    // Tokenni yangilash (rotation uchun)
    public void UpdateTokens(string newAccessToken, DateTime newAccessTokenExpiresAt,
                             string newRefreshToken, DateTime newRefreshTokenExpiresAt)
    {
        AccessToken = newAccessToken;
        AccessTokenExpiresAt = newAccessTokenExpiresAt;

        RefreshToken = newRefreshToken;
        RefreshTokenExpiresAt = newRefreshTokenExpiresAt;

        Status = TokenStatus.Active;
    }
}