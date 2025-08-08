using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Abstractions;

namespace Dorixona.Application.Services.Pills;

public interface IPillService
{
    Task<IEnumerable<PillDto>> GetAllAsync();
    Task<PillDto?> GetByIdAsync(Guid id);
    Task<Result<PillDto>> CreateAsync(CreatePillDto dto);
    Task<Result<PillDto>> UpdateAsync(Guid id, UpdatePillDto dto);
    Task<Result> DeleteAsync(Guid id);
}
