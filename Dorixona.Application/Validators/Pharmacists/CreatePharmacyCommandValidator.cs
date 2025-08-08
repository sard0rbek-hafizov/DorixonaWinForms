using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using FluentValidation;

namespace Dorixona.Application.Validators.Pharmacists;

public class CreatePharmacyCommandValidator : AbstractValidator<CreatePharmacyDto>
{
    public CreatePharmacyCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Dorixona nomi majburiy.")
            .MaximumLength(100).WithMessage("Dorixona nomi 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Manzil majburiy.")
            .MaximumLength(200).WithMessage("Manzil 200 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon raqami majburiy.")
            .Matches(@"^\+998\d{9}$").WithMessage("Telefon raqami +998901234567 formatida bo‘lishi kerak.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email majburiy.")
            .EmailAddress().WithMessage("Email noto‘g‘ri formatda.");

        RuleFor(x => x.LicenseNumber)
            .NotEmpty().WithMessage("Litsenziya raqami majburiy.")
            .MaximumLength(50).WithMessage("Litsenziya raqami 50 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.WorkingHours)
            .NotEmpty().WithMessage("Ish vaqti majburiy.")
            .MaximumLength(100).WithMessage("Ish vaqti 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.IsOpen24Hours)
            .NotNull().WithMessage("24 soat ishlash holati majburiy.");

        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90).WithMessage("Latitude -90 dan +90 gacha bo‘lishi kerak.");

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180).WithMessage("Longitude -180 dan +180 gacha bo‘lishi kerak.");

        RuleFor(x => x.IsConfirmed)
            .NotNull().WithMessage("Tasdiqlash holati majburiy.");

        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("Faol holat majburiy.");
    }
}