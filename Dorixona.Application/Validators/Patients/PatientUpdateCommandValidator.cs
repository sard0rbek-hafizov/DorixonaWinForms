using Dorixona.Application.Features.Patients.Commands;
using Dorixona.Domain.Models.PatientModel.PatientValidators;
using FluentValidation;

namespace Dorixona.Application.Validators.Patients;

public class PatientUpdateCommandValidator : AbstractValidator<UpdatePatientCommand>
{
    public PatientUpdateCommandValidator()
    {
        RuleFor(x => x.PatientId)
            .NotEmpty().WithMessage("Foydalanuvchi ID majburiy.");

        RuleFor(x => x.PatientDto)
            .NotNull().WithMessage("Patient DTO bo‘sh bo‘lmasligi kerak.")
            .SetValidator(new PatientUpdateDtoValidator());
    }
}