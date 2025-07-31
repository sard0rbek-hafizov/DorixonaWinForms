using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Models.PillsModel.PillDTO;

namespace Dorixona.Domain.Models.PillsModel.IPillRepositories;
public interface IPillQueryService
{
    Task<PillDto?> GetByIdAsync(Guid pillId);
    Task<IReadOnlyList<PillDto>> GetFilteredListAsync(FilterPillDto filter);
    Task<int> CountAsync(FilterPillDto filter);
}
