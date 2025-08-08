using Dorixona.Domain.Models.AuthModel.Entities;
using System.Linq.Expressions;

namespace Dorixona.Domain.Models.AuthModel.Specs;

public static class RefreshTokenSpecs
{
    public static Expression<Func<RefreshToken, bool>> IsActive() =>
        token => token.RevokedAt == null && token.ExpiresAt > DateTime.UtcNow;

    public static Expression<Func<RefreshToken, bool>> IsExpired() =>
        token => token.ExpiresAt <= DateTime.UtcNow;

    public static Expression<Func<RefreshToken, bool>> IsRevoked() =>
        token => token.RevokedAt != null;

    public static Expression<Func<RefreshToken, bool>> BelongsToUser(Guid userId) =>
        token => token.UserId == userId;
}
