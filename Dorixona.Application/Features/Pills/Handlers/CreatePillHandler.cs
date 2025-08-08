using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.PillsModel.PillEntities;

namespace Dorixona.Application.Features.Pills.Handlers;

public class CreatePillHandler
{
    private readonly IPillRepository _pillRepository;

    public CreatePillHandler(IPillRepository pillRepository)
    {
        _pillRepository = pillRepository;
    }

    public async Task<Result<bool>> HandleAsync(CreatePillDto dto, CancellationToken cancellationToken)
    {
        var pill = new Pill
        {
            Name = dto.Name,
            Description = dto.Description,
            Manufacturer = dto.Manufacturer,
            ManufactureDate = dto.ManufactureDate,
            ExpiryDate = dto.ExpiryDate,
            Price = dto.Price,
            Dosage = dto.Dosage,
            PillType = dto.PillType,
            StockQuantity = dto.StockQuantity,
            ImageUrl = dto.ImageUrl,
            Barcode = dto.Barcode,
            Ingredients = dto.Ingredients,
            IsPrescriptionRequired = dto.IsPrescriptionRequired,
            CategoryId = dto.CategoryId,
            PharmacyId = dto.PharmacyId
        };

        return await _pillRepository.AddAsync(pill, cancellationToken);
    }
}