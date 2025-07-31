using FluentValidation;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

namespace Dorixona.Domain.Models.PharmacyModel.PharmacyValidators;

public class PharmacyDtoValidator : AbstractValidator<PharmacyDto>
{
    public PharmacyDtoValidator()
    {
        // ID
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID bo‘sh bo‘lmasligi kerak.")
            .NotEqual(Guid.Empty).WithMessage("Noto‘g‘ri ID.");

        // Nomi
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Dorixona nomi bo‘sh bo‘lmasligi kerak.")
            .MaximumLength(100).WithMessage("Dorixona nomi 100 ta belgidan oshmasligi kerak.");

        // Manzil
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Manzil bo‘sh bo‘lmasligi kerak.")
            .MaximumLength(200).WithMessage("Manzil 200 ta belgidan oshmasligi kerak.");

        // Telefon raqami
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon raqam bo‘sh bo‘lmasligi kerak.")
            .Matches(@"^\+998\d{9}$").WithMessage("Telefon raqam +998XXXXXXXXX formatida bo‘lishi kerak.");

        // Email
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email bo‘sh bo‘lmasligi kerak.")
            .EmailAddress().WithMessage("Email manzili noto‘g‘ri formatda.");

        // Litsenziya raqami
        RuleFor(x => x.LicenseNumber)
            .NotEmpty().WithMessage("Litsenziya raqami bo‘sh bo‘lmasligi kerak.")
            .MaximumLength(50).WithMessage("Litsenziya raqami 50 ta belgidan oshmasligi kerak.");

        // IsActive & IsConfirmed
        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("IsActive qiymati ko‘rsatilishi kerak.");

        RuleFor(x => x.IsConfirmed)
            .NotNull().WithMessage("IsConfirmed qiymati ko‘rsatilishi kerak.");

        // CreatedAt
        RuleFor(x => x.CreatedAt)
            .NotEmpty().WithMessage("CreatedAt sanasi bo‘sh bo‘lmasligi kerak.");

        // UpdatedAt - ixtiyoriy, ammo agar mavjud bo‘lsa, CreatedAt dan keyin bo‘lishi kerak
        When(x => x.UpdatedAt.HasValue, () =>
        {
            RuleFor(x => x)
                .Must(x => x.UpdatedAt > x.CreatedAt)
                .WithMessage("UpdatedAt CreatedAt dan keyin bo‘lishi kerak.");
        });
    }
}
