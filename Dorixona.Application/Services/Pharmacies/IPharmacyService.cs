using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

namespace Dorixona.Application.Services.Pharmacies;

public interface IPharmacyService
{
    Task<IEnumerable<PharmacyDto>> GetAllAsync();
    Task<PharmacyDto?> GetByIdAsync(Guid id);
    Task<Result<PharmacyDto>> CreateAsync(CreatePharmacyDto dto);
    Task<Result<PharmacyDto>> UpdateAsync(Guid id, UpdatePharmacyDto dto);
    Task<Result> DeleteAsync(Guid id);
}
