using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PillsModel.PillEntities;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pills.Commands;

public class CreatePillCommand : IRequest<Result<Guid>>
{
    public CreatePillDto Dto { get; set; } = default!;
}

public class CreatePillCommandHandler : IRequestHandler<CreatePillCommand, Result<Guid>>
{
    private readonly IPillRepository _pillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePillCommandHandler(IPillRepository pillRepository, IUnitOfWork unitOfWork)
    {
        _pillRepository = pillRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreatePillCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var pill = new Pill
        {
            Id = Guid.NewGuid(),
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
            PharmacyId = dto.PharmacyId,
            CreateDate = DateTime.UtcNow,
            UpdateDate = DateTime.UtcNow
        };

        var result = await _pillRepository.AddAsync(pill, cancellationToken);
        if (!result.IsSuccess)
            return Result<Guid>.Failure(result.Error!);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result<Guid>.Success(pill.Id);
    }
}
