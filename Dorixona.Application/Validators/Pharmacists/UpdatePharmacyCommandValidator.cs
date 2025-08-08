using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using FluentValidation;

namespace Dorixona.Application.Validators.Pharmacists;

public class UpdatePharmacyCommandValidator : AbstractValidator<UpdatePharmacyDto>
{
    public UpdatePharmacyCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID majburiy.");

        RuleFor(x => x.Name)
            .MaximumLength(100).WithMessage("Dorixona nomi 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Address)
            .MaximumLength(200).WithMessage("Manzil 200 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+998\d{9}$")
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
            .WithMessage("Telefon raqam +998901234567 formatida bo‘lishi kerak.");

        RuleFor(x => x.Email)
            .EmailAddress()
            .When(x => !string.IsNullOrWhiteSpace(x.Email))
            .WithMessage("Email noto‘g‘ri formatda.");

        RuleFor(x => x.LicenseNumber)
            .MaximumLength(50).WithMessage("Litsenziya raqami 50 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.WorkingHours)
            .MaximumLength(100).WithMessage("Ish vaqti 100 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Latitude)
            .InclusiveBetween(-90, 90)
            .When(x => x.Latitude.HasValue)
            .WithMessage("Latitude -90 dan +90 gacha bo‘lishi kerak.");

        RuleFor(x => x.Longitude)
            .InclusiveBetween(-180, 180)
            .When(x => x.Longitude.HasValue)
            .WithMessage("Longitude -180 dan +180 gacha bo‘lishi kerak.");

        RuleFor(x => x.WorkingHours)
            .NotEmpty()
            .When(x => x.IsOpen24Hours == false || x.IsOpen24Hours == null)
            .WithMessage("Ish vaqti majburiy, agar dorixona 24 soat ochiq bo‘lmasa.");
    }
}