using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using FluentValidation;

namespace Dorixona.Application.Validators.Pharmacists;

public class FilterPharmacyQueryValidator : AbstractValidator<FilterPharmacyDto>
{
    public FilterPharmacyQueryValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(100).WithMessage("Nomi 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Address)
            .MaximumLength(200).WithMessage("Manzil 200 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+998\d{9}$")
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
            .WithMessage("Telefon raqam +998901234567 formatida bo‘lishi kerak.");
    }
}
