using Dorixona.Domain.Models.PharmacyModel.Entities;

namespace Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
public interface IPharmacyRepository
{
    Task<Pharmacy?> GetByIdAsync(Guid id);
    Task<List<Pharmacy>> GetAllAsync();
    Task<List<Pharmacy>> FilterAsync(string? name, string? address, string? phoneNumber);
    Task AddAsync(Pharmacy pharmacy);
    Task UpdateAsync(Pharmacy pharmacy);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
