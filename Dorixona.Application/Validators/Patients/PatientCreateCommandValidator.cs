using Dorixona.Application.Features.Patients.Commands;
using Dorixona.Domain.Models.PatientModel.PatientValidators;
using FluentValidation;

namespace Dorixona.Application.Validators.Patients;

public class PatientCreateCommandValidator : AbstractValidator<CreatePatientCommand>
{
    public PatientCreateCommandValidator()
    {
        RuleFor(x => x.PatientDto)
            .NotNull().WithMessage("Patient DTO bo‘sh bo‘lmasligi kerak.")
            .SetValidator(new PatientCreateDtoValidator());
    }
}
