using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.PillsModel.PillDTO;

namespace Dorixona.Application.Features.Pills.Handlers;

public class GetPillsForAdminHandler
{
    private readonly IPillQueryService _pillQueryService;

    public GetPillsForAdminHandler(IPillQueryService pillQueryService)
    {
        _pillQueryService = pillQueryService;
    }

    public async Task<PagedResultDto<GetPillForAdminDto>> HandleAsync(FilterPillDto filter, int page, int pageSize)
    {
        var pills = await _pillQueryService.GetFilteredListAsync(filter);
        var totalCount = await _pillQueryService.CountAsync(filter);
        var paged = pills.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new PagedResultDto<GetPillForAdminDto>
        {
            TotalCount = totalCount,
            PageSize = pageSize,
            CurrentPage = page,
            Items = paged.Select(p => new GetPillForAdminDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Manufacturer = p.Manufacturer,
                Price = p.Price,
                PillType = p.PillType,
                StockQuantity = p.StockQuantity,
                Barcode = p.Barcode,
                ExpiryDate = DateTime.Parse(p.ExpiryDate.ToString()),
                PharmacyName = p.PharmacyShortDto.FirstOrDefault()?.Name ?? "",
                CategoryName = "", // Add logic to fetch category name
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }).ToList()
        };
    }
}
