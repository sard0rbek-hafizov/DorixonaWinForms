using Dorixona.Application.DTOs.Pharmacies;
using FluentValidation;

namespace Dorixona.Application.Validators.Pills;

public class ExportPharmacyPillsValidator : AbstractValidator<ExportPharmacyDto>
{
    public ExportPharmacyPillsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Dorixona ID majburiy.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Dorixona nomi majburiy.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Manzil majburiy.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Telefon raqam majburiy.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email majburiy.")
            .EmailAddress().WithMessage("Email formati noto‘g‘ri.");

        RuleFor(x => x.ManagerFullName)
            .NotEmpty().WithMessage("Menejerning to‘liq ismi majburiy.");

        RuleFor(x => x.WorkingHours)
            .NotEmpty().WithMessage("Ish vaqti majburiy.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Dorixona tavsifi majburiy.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Status noto‘g‘ri.");

        RuleFor(x => x.CreatedAt)
            .LessThanOrEqualTo(x => x.UpdatedAt).WithMessage("Yaratilgan sana yangilangan sanadan keyin bo‘lmasligi kerak.");
    }
}