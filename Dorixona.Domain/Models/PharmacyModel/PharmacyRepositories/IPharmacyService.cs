using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

namespace Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
public interface IPharmacyService
{
    Task<Result<bool>> CreateAsync(CreatePharmacyDto dto);
    Task<Result<bool>> UpdateAsync(UpdatePharmacyDto dto);
    Task<Result<bool>> DeleteAsync(Guid id);
    Task<Result<PharmacyDto>> GetByIdAsync(Guid id);
    Task<Result<IReadOnlyList<PharmacyDto>>> GetAllAsync();
}
