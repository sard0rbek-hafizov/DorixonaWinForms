using Dorixona.Domain.Models.PharmacistModel.PharmacistEntities;

namespace Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;

public interface IPharmacistRepository
{
    Task<Pharmacist?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<Pharmacist>> GetAllAsync();
    Task<IReadOnlyList<Pharmacist>> GetByPharmacyIdAsync(Guid pharmacyId);
    Task AddAsync(Pharmacist pharmacist);
    Task UpdateAsync(Pharmacist pharmacist);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
