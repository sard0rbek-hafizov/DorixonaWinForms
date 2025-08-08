using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.PillsModel.PillDTO;

namespace Dorixona.Application.Features.Pills.Handlers;

public class FilterPillsHandler
{
    private readonly IPillQueryService _pillQueryService;

    public FilterPillsHandler(IPillQueryService pillQueryService)
    {
        _pillQueryService = pillQueryService;
    }

    public async Task<IReadOnlyList<PillDto>> HandleAsync(FilterPillDto filter)
    {
        return await _pillQueryService.GetFilteredListAsync(filter);
    }
}