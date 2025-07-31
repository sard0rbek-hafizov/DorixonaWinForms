using Dorixona.Domain.Models.PillsModel.PillDTO;
using FluentValidation;
namespace Dorixona.Domain.Models.PillsModel.PillValidators;

public class FilterPillDtoValidator : AbstractValidator<FilterPillDto>
{
    public FilterPillDtoValidator()
    {
        RuleFor(x => x.MinPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Minimal narx 0 dan kam bo'lmasligi kerak.");

        RuleFor(x => x.MaxPrice)
            .GreaterThanOrEqualTo(x => x.MinPrice)
            .WithMessage("Maksimal narx minimal narxdan katta bo'lishi kerak.");

        // Optional: Name yoki search query uchun uzunlik
        RuleFor(x => x.Search)
            .MaximumLength(100).WithMessage("Qidiruv so‘rovi juda uzun.");
    }
}
