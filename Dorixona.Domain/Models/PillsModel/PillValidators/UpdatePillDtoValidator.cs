using Dorixona.Application.DTOs.Pills;
using FluentValidation;
namespace Dorixona.Domain.Models.PillsModel.PillValidators;

public class UpdatePillDtoValidator : AbstractValidator<UpdatePillDto>
{
    public UpdatePillDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID bo‘sh bo‘lmasligi kerak.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Dori nomi majburiy.")
            .MaximumLength(100).WithMessage("Dori nomi maksimal 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Tavsif maksimal 500 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Manufacturer)
            .NotEmpty().WithMessage("Ishlab chiqaruvchi nomi majburiy.")
            .MaximumLength(100).WithMessage("Ishlab chiqaruvchi nomi maksimal 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.ManufactureDate)
            .NotEmpty().WithMessage("Ishlab chiqarilgan sana majburiy.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Ishlab chiqarilgan sana kelajak bo‘lishi mumkin emas.");

        RuleFor(x => x.ExpiryDate)
            .NotEmpty().WithMessage("Yaroqlilik muddati majburiy.")
            .GreaterThan(DateTime.UtcNow).WithMessage("Yaroqlilik muddati o‘tgan bo‘lmasligi kerak.");

        RuleFor(x => x.Price)
            .InclusiveBetween(0.01m, 100_000).WithMessage("Narx 0.01 dan 100,000 gacha bo'lishi kerak.");

        RuleFor(x => x.Dosage)
            .NotEmpty().WithMessage("Dozalash majburiy.")
            .MaximumLength(50).WithMessage("Dozalash maksimal 50 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.PillType)
            .IsInEnum().WithMessage("Dorining turi noto‘g‘ri.");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Ombordagi soni manfiy bo'lishi mumkin emas.");

        RuleFor(x => x.ImageUrl)
            .Must(uri => string.IsNullOrWhiteSpace(uri) || Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            .WithMessage("Rasm URL noto‘g‘ri formatda.");

        RuleFor(x => x.Barcode)
            .MaximumLength(100).WithMessage("Shtrixkod maksimal 100 belgidan oshmasligi kerak.");

        RuleFor(x => x.Ingredients)
            .MaximumLength(1000).WithMessage("Ingredientlar maksimal 1000 belgidan oshmasligi kerak.");

        RuleFor(x => x.Pharmacy)
            .NotNull().WithMessage("Dorixona obyekti bo‘sh bo‘lmasligi kerak.")
            .SetValidator(new PharmacyDtoValidator());
    }
}
