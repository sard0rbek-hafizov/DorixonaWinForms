using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.PillsModel.PillDTO;

namespace Dorixona.Application.Features.Pills.Handlers;

public class GetPillsForSellerHandler
{
    private readonly IPillQueryService _pillQueryService;

    public GetPillsForSellerHandler(IPillQueryService pillQueryService)
    {
        _pillQueryService = pillQueryService;
    }

    public async Task<IReadOnlyList<GetPillForSellerDto>> HandleAsync(FilterPillDto filter)
    {
        var pills = await _pillQueryService.GetFilteredListAsync(filter);

        return pills.Select(p => new GetPillForSellerDto
        {
            Name = p.Name,
            Description = p.Description,
            CategoryName = "", // Add logic to fetch category name
            Price = p.Price,
            StockQuantity = p.StockQuantity
        }).ToList();
    }
}