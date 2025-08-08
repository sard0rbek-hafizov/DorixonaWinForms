using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pills.Commands;

public class UpdatePillCommand : IRequest<Result>
{
    public UpdatePillDto Dto { get; set; } = default!;
}

public class UpdatePillCommandHandler : IRequestHandler<UpdatePillCommand, Result>
{
    private readonly IPillRepository _pillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePillCommandHandler(IPillRepository pillRepository, IUnitOfWork unitOfWork)
    {
        _pillRepository = pillRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePillCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var existingResult = await _pillRepository.GetByIdAsync(dto.Id, cancellationToken);
        if (!existingResult.IsSuccess)
            return Result.Failure(existingResult.Error!);

        var pill = existingResult.Value!;
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
        pill.UpdateDate = DateTime.UtcNow;

        var updateResult = await _pillRepository.UpdateAsync(pill, cancellationToken);
        if (!updateResult.IsSuccess)
            return Result.Failure(updateResult.Error!);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
