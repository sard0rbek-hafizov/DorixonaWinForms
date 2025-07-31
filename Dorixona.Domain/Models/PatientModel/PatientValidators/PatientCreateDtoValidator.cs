using FluentValidation;
using Dorixona.Domain.Models.PatientModel.PatientDTO;

namespace Dorixona.Domain.Models.PatientModel.PatientValidators;

public class PatientCreateDtoValidator : AbstractValidator<PatientCreateDto>
{
    public PatientCreateDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ism majburiy.")
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Familiya majburiy.")
            .MaximumLength(50);

        RuleFor(x => x.MiddleName)
            .MaximumLength(50).When(x => x.MiddleName != null);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email majburiy.")
            .EmailAddress().WithMessage("Email noto‘g‘ri formatda.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol majburiy.")
            .MinimumLength(6).WithMessage("Parol kamida 6 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Tug‘ilgan sana majburiy.")
            .LessThan(DateTime.Today).WithMessage("Tug‘ilgan sana bugungidan kichik bo‘lishi kerak.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+?[0-9]{9,15}$").When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
            .WithMessage("Telefon raqami noto‘g‘ri.");

        RuleFor(x => x.Address)
            .MaximumLength(100);

        RuleFor(x => x.AllergyInfo)
            .MaximumLength(200);

        RuleFor(x => x.MedicalHistory)
            .MaximumLength(500);

        RuleFor(x => x.EmergencyContact)
            .MaximumLength(200);

        RuleFor(x => x.BloodType)
            .MaximumLength(200);
    }
}
