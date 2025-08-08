using Dorixona.Domain.Models.AuthModel.Entities;

namespace Dorixona.Domain.Models.AuthModel.Repositories;

public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken token, CancellationToken cancellationToken = default);

    Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<RefreshToken>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);

    Task InvalidateTokenAsync(Guid tokenId, CancellationToken cancellationToken = default);

    Task InvalidateAllActiveTokensAsync(Guid userId, CancellationToken cancellationToken = default);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
