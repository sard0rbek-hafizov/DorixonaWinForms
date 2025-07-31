using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

namespace Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;

public interface IPharmacyValidator
{
    Task<Result<bool>> ValidateCreateAsync(CreatePharmacyDto dto);
    Task<Result<bool>> ValidateUpdateAsync(UpdatePharmacyDto dto);
    Task<Result<bool>> ValidateIdAsync(Guid pharmacyId);
}
