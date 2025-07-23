namespace Dorixona.Domain.Models.PillsModel.IPillRepositories;
public interface IPillRepository
{
    Task<List<Pill>> GetPillAsync();
    Task UpdateAsync(Pill pill);
    Task AddAsync(Pill pillModel, CancellationToken cancellationToken);
    Task Delete(Pill pill);

    Task<Pill> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
