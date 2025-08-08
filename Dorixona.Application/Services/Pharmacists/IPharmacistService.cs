using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

namespace Dorixona.Application.Services.Pharmacists;

public interface IPharmacistService
{
    Task<IEnumerable<PharmacistDto>> GetAllAsync();
    Task<PharmacistDto?> GetByIdAsync(Guid id);
    Task<Result<PharmacistDto>> CreateAsync(PharmacistCreateDto dto);
    Task<Result<PharmacistDto>> UpdateAsync(Guid id, PharmacistUpdateDto dto);
    Task<Result> DeleteAsync(Guid id);
}
