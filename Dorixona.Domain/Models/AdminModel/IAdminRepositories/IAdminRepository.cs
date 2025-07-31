using Dorixona.Domain.Models.AdminModel.AdminEntities;

namespace Dorixona.Domain.Models.AdminModel.IAdminRepositories;

public interface IAdminRepository
{
    Task<Admin?> GetByIdAsync(Guid id);
    Task<IEnumerable<Admin>> GetAllAsync();
    Task CreateAsync(Admin admin);
    Task UpdateAsync(Admin admin);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}
