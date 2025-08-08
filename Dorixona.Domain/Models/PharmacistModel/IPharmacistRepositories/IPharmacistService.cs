using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

namespace Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;

public interface IPharmacistService
{
    Task<Result<bool>> CreateAsync(PharmacistCreateDto dto);
    Task<Result<bool>> UpdateAsync(PharmacistUpdateDto dto);
    Task<Result<bool>> DeleteAsync(Guid id);
}
