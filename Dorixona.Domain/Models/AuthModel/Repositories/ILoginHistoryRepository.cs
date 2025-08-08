using Dorixona.Domain.Models.AuthModel.Entities;

namespace Dorixona.Domain.Models.AuthModel.Repositories;

public interface ILoginHistoryRepository
{
    Task AddAsync(LoginHistory history, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<LoginHistory>> GetByUserIdAsync(
        Guid userId,
        int limit = 20,
        CancellationToken cancellationToken = default);

    Task<LoginHistory?> GetLastLoginAsync(
        Guid userId,
        CancellationToken cancellationToken = default);
}
