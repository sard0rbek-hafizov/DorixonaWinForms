namespace Dorixona.Infrastructure.Authentication.RefreshTokens;

public interface IRefreshTokenService
{
    Task<RefreshToken?> GetValidRefreshTokenAsync(string token);
    Task<RefreshToken> CreateRefreshTokenAsync(Guid userId, string ipAddress, string device, string deviceId);
    Task RevokeRefreshTokenAsync(RefreshToken refreshToken);
}
