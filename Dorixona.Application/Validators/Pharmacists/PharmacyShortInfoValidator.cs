using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using FluentValidation;

namespace Dorixona.Application.Validators.Pharmacists;

public class PharmacyShortInfoValidator : AbstractValidator<PharmacyShortDto>
{
    public PharmacyShortInfoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID majburiy.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Nomi majburiy.")
            .MaximumLength(100).WithMessage("Nomi 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Manzil majburiy.")
            .MaximumLength(200).WithMessage("Manzil 200 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon raqam majburiy.")
            .Matches(@"^\+998\d{9}$").WithMessage("Telefon raqam +998901234567 formatida bo‘lishi kerak.");
    }
}