using Dorixona.Domain.Models.PatientModel.PatientDTO;
using FluentValidation;

namespace Dorixona.Application.Validators.Patients;

public class PatientFilterValidator : AbstractValidator<PatientFilterDto>
{
    public PatientFilterValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("Sahifa raqami 0 dan katta bo'lishi kerak.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("Sahifa hajmi 0 dan katta bo'lishi kerak.");

        RuleFor(x => x.FullName)
            .MaximumLength(100).WithMessage("To‘liq ism maksimal 100 ta belgidan oshmasligi kerak.")
            .When(x => !string.IsNullOrWhiteSpace(x.FullName));

        RuleFor(x => x.ToBirthDate)
            .GreaterThanOrEqualTo(x => x.FromBirthDate)
            .When(x => x.FromBirthDate.HasValue && x.ToBirthDate.HasValue)
            .WithMessage("ToBirthDate FromBirthDate dan oldin bo‘lishi mumkin emas.");
    }
}