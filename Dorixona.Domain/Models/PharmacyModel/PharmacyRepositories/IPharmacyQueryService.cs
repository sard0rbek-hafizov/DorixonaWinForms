using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

namespace Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
public interface IPharmacyQueryService
{
    Task<PharmacyDto?> GetByIdAsync(Guid id);
    Task<List<PharmacyDto>> GetAllAsync();
    Task<List<PharmacyDto>> FilterAsync(FilterPharmacyDto filter);
}
