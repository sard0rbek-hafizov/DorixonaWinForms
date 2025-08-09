namespace Dorixona.Infrastructure.Authentication.RefreshTokens;

public interface IRefreshTokenRepository4
{
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task AddAsync(RefreshToken refreshToken);
    Task UpdateAsync(RefreshToken refreshToken);
}
