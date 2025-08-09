using Dorixona.Infrastructure.Authentication.Jwt;
using Microsoft.Extensions.Logging;

namespace Dorixona.Infrastructure.Authentication.RefreshTokens;
public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenRepository4 _refreshTokenRepository;
    private readonly JwtSettings _jwtSettings;
    private readonly ILogger<RefreshTokenService> _logger;

    public RefreshTokenService(
        IRefreshTokenRepository4 refreshTokenRepository,
        JwtSettings jwtSettings,
        ILogger<RefreshTokenService> logger)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _jwtSettings = jwtSettings;
        _logger = logger;
    }

    public async Task<RefreshToken?> GetValidRefreshTokenAsync(string token)
    {
        var refreshToken = await _refreshTokenRepository.GetByTokenAsync(token);

        if (refreshToken == null)
        {
            _logger.LogWarning("Refresh token not found.");
            return null;
        }

        if (refreshToken.IsExpired() || refreshToken.Status != Domain.Enums.TokenStatus.Active)
        {
            _logger.LogWarning("Refresh token expired or not active.");
            return null;
        }

        return refreshToken;
    }

    public async Task<RefreshToken> CreateRefreshTokenAsync(Guid userId, string ipAddress, string device, string deviceId)
    {
        var expiresAt = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationDays);
        var tokenBytes = new byte[64];
        using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
        rng.GetBytes(tokenBytes);
        var token = Convert.ToBase64String(tokenBytes);

        var refreshToken = new RefreshToken(userId, token, expiresAt, ipAddress, device, deviceId);

        await _refreshTokenRepository.AddAsync(refreshToken);

        return refreshToken;
    }

    public async Task RevokeRefreshTokenAsync(RefreshToken refreshToken)
    {
        refreshToken.Revoke();
        await _refreshTokenRepository.UpdateAsync(refreshToken);
    }
}