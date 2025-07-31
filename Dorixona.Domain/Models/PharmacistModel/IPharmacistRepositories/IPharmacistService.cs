using Dorixona.Domain.Abstractions;

namespace Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;

public interface IPharmacistService
{
    Task<Result<bool>> CreateAsync(CreatePharmacistDto dto);
    Task<Result<bool>> UpdateAsync(UpdatePharmacistDto dto);
    Task<Result<bool>> DeleteAsync(Guid id);
}
