using Dorixona.Application.Features.Patients.Commands;
using Dorixona.Domain.Models.PatientModel.PatientValidators;
using FluentValidation;

namespace Dorixona.Application.Validators.Patients;

public class PatientStatusUpdateValidator : AbstractValidator<UpdatePatientStatusCommand>
{
    public PatientStatusUpdateValidator()
    {
        RuleFor(x => x.StatusDto)
            .NotNull().WithMessage("Status DTO bo‘sh bo‘lmasligi kerak.")
            .SetValidator(new PatientStatusUpdateDtoValidator());
    }
}