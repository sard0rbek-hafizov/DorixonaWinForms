using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistValidators;

public class PharmacistUpdateDtoValidator : AbstractValidator<PharmacistUpdateDto>
{
    public PharmacistUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id bo‘sh bo‘lmasligi kerak.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId majburiy.");

        RuleFor(x => x.PharmacyId)
            .NotEmpty().WithMessage("PharmacyId majburiy.");

        RuleFor(x => x.Certification)
            .MaximumLength(255).WithMessage("Certification 255 belgidan oshmasligi kerak.");

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("StartDate hozirgi kundan oldin yoki teng bo‘lishi kerak.");
    }
}
