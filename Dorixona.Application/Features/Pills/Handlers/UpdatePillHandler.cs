using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;

namespace Dorixona.Application.Features.Pills.Handlers;

public class UpdatePillHandler
{
    private readonly IPillRepository _pillRepository;

    public UpdatePillHandler(IPillRepository pillRepository)
    {
        _pillRepository = pillRepository;
    }

    public async Task<Result<bool>> HandleAsync(UpdatePillDto dto, CancellationToken cancellationToken)
    {
        var result = await _pillRepository.GetByIdAsync(dto.Id, cancellationToken);
        if (result.IsFailure) return Result.Failure<bool>(result.Error);

        var pill = result.Value;

        pill.Name = dto.Name;
        pill.Description = dto.Description;
        pill.Manufacturer = dto.Manufacturer;
        pill.ManufactureDate = dto.ManufactureDate;
        pill.ExpiryDate = dto.ExpiryDate;
        pill.Price = dto.Price;
        pill.Dosage = dto.Dosage;
        pill.PillType = dto.PillType;
        pill.StockQuantity = dto.StockQuantity;
        pill.ImageUrl = dto.ImageUrl;
        pill.Barcode = dto.Barcode;
        pill.Ingredients = dto.Ingredients;
        pill.IsPrescriptionRequired = dto.IsPrescriptionRequired;
        pill.CategoryId = dto.CategoryId;
        pill.PharmacyId = dto.Pharmacy.Id;

        return await _pillRepository.UpdateAsync(pill, cancellationToken);
    }
}
