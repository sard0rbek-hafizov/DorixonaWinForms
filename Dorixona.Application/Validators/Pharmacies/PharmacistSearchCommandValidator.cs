using FluentValidation;

namespace Dorixona.Application.Validators.Pharmacies;

public class PharmacistSearchCommandValidator : AbstractValidator<string>
{
    public PharmacistSearchCommandValidator()
    {
        RuleFor(x => x)
            .NotEmpty().WithMessage("Qidiruv so‘zi bo‘sh bo‘lmasligi kerak.")
            .MinimumLength(2).WithMessage("Qidiruv so‘zi kamida 2 ta belgidan iborat bo‘lishi kerak.");
    }
}
