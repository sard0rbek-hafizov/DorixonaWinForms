using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;

namespace Dorixona.Application.Features.Pills.Handlers;

public class GetPillByIdHandler
{
    private readonly IPillQueryService _pillQueryService;

    public GetPillByIdHandler(IPillQueryService pillQueryService)
    {
        _pillQueryService = pillQueryService;
    }

    public async Task<PillDto?> HandleAsync(Guid pillId)
    {
        return await _pillQueryService.GetByIdAsync(pillId);
    }
}