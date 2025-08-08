using Dorixona.Application.Features.Patients.Commands;
using FluentValidation;

namespace Dorixona.Application.Validators.Patients;

public class ChangePatientPasswordValidator : AbstractValidator<ChangePatientPasswordCommand>
{
    public ChangePatientPasswordValidator()
    {
        RuleFor(x => x.PatientId)
            .NotEmpty().WithMessage("Foydalanuvchi ID majburiy.");

        RuleFor(x => x.PasswordDto)
            .NotNull().WithMessage("Parol DTO bo‘sh bo‘lmasligi kerak.");

        RuleFor(x => x.PasswordDto.CurrentPassword)
            .NotEmpty().WithMessage("Joriy parol majburiy.")
            .MinimumLength(6).WithMessage("Joriy parol kamida 6 ta belgidan iborat bo‘lishi kerak.");

        RuleFor(x => x.PasswordDto.NewPassword)
            .NotEmpty().WithMessage("Yangi parol majburiy.")
            .MinimumLength(6).WithMessage("Yangi parol kamida 6 ta belgidan iborat bo‘lishi kerak.")
            .NotEqual(x => x.PasswordDto.CurrentPassword).WithMessage("Yangi parol joriy paroldan farq qilishi kerak.");
    }
}
