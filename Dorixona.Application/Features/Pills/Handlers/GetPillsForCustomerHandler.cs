using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.PillsModel.PillDTO;

namespace Dorixona.Application.Features.Pills.Handlers;

public class GetPillsForCustomerHandler
{
    private readonly IPillQueryService _pillQueryService;

    public GetPillsForCustomerHandler(IPillQueryService pillQueryService)
    {
        _pillQueryService = pillQueryService;
    }

    public async Task<IReadOnlyList<GetPillForCustomerDto>> HandleAsync(FilterPillDto filter)
    {
        var pills = await _pillQueryService.GetFilteredListAsync(filter);

        return pills.Select(p => new GetPillForCustomerDto
        {
            Name = p.Name,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            PharmacyName = p.PharmacyShortDto.FirstOrDefault()?.Name ?? ""
        }).ToList();
    }
}
