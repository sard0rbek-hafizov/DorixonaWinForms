using FluentValidation;
using Dorixona.Domain.Models.PatientModel.PatientDTO;

namespace Dorixona.Domain.Models.PatientModel.PatientValidators;

public class PatientUpdateDtoValidator : AbstractValidator<PatientUpdateDto>
{
    public PatientUpdateDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.MiddleName)
            .MaximumLength(50).When(x => x.MiddleName != null);

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
