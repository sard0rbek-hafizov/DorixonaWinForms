using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.AuthModel.Entities;

namespace Dorixona.Domain.Models.AuthModel.Specs;

public static class AuthTokenSpecs
{
    public static bool IsExpired(RefreshToken token)
    {
        return token.ExpiresAt <= DateTime.UtcNow;
    }

    public static bool IsRevoked(RefreshToken token)
    {
        return token.Status == TokenStatus.Revoked;
    }

    public static bool IsValid(RefreshToken token)
    {
        return token.Status == TokenStatus.Active && token.ExpiresAt > DateTime.UtcNow;
    }

    public static bool BelongsToUser(RefreshToken token, Guid userId)
    {
        return token.UserId == userId;
    }

    public static bool BelongsToDevice(RefreshToken token, string deviceId)
    {
        return token.DeviceId == deviceId;
    }
}
