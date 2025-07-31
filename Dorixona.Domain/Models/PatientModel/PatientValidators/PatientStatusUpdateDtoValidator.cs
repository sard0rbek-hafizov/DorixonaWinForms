using FluentValidation;
using Dorixona.Domain.Models.PatientModel.PatientDTO;

namespace Dorixona.Domain.Models.PatientModel.PatientValidators;

public class PatientStatusUpdateDtoValidator : AbstractValidator<PatientStatusUpdateDto>
{
    public PatientStatusUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id majburiy.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Noto‘g‘ri status qiymati.");
    }
}
