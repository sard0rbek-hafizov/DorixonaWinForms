using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using FluentValidation;
namespace Dorixona.Domain.Models.PillsModel.PillValidators;
public class PharmacyDtoValidator : AbstractValidator<PharmacyDto>
{
    public PharmacyDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Dorixona ID bo'sh bo'lmasligi kerak.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Dorixona nomi majburiy.");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Manzil majburiy.");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon raqam majburiy.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email majburiy.")
            .EmailAddress().WithMessage("Email noto‘g‘ri formatda.");
        RuleFor(x => x.LicenseNumber).NotEmpty().WithMessage("Litsenziya raqami majburiy.");
    }
}
