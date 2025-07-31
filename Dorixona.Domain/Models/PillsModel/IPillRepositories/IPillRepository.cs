using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PillsModel.PillEntities;
namespace Dorixona.Domain.Models.PillsModel.IPillRepositories;
public interface IPillRepository
{
    Task<Result<Pill>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<IReadOnlyList<Pill>>> GetAllAsync(CancellationToken cancellationToken);
    Task<Result<bool>> AddAsync(Pill pill, CancellationToken cancellationToken);
    Task<Result<bool>> UpdateAsync(Pill pill, CancellationToken cancellationToken);
    Task<Result<bool>> DeleteAsync(Pill pill, CancellationToken cancellationToken);
}
