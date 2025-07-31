using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistValidators;

public class PharmacistFilterDtoValidator : AbstractValidator<PharmacistFilterDto>
{
    public PharmacistFilterDtoValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("Page number 1 dan katta bo‘lishi kerak.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100).WithMessage("Page size 1 dan 100 gacha bo‘lishi kerak.");

        When(x => x.StartDateFrom.HasValue && x.StartDateTo.HasValue, () =>
        {
            RuleFor(x => x.StartDateTo)
                .GreaterThanOrEqualTo(x => x.StartDateFrom)
                .WithMessage("StartDateTo StartDateFrom dan keyin bo‘lishi kerak.");
        });
    }
}
