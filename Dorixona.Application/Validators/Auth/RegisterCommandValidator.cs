using Dorixona.Application.Features.Auth.Commands;
using FluentValidation;

namespace Dorixona.Application.Validators.Auth;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.RegisterDto.FullName)
            .NotEmpty().WithMessage("To'liq ism bo'sh bo'lishi mumkin emas.")
            .MaximumLength(100).WithMessage("To'liq ism maksimal 100 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.RegisterDto.FirstName)
            .NotEmpty().WithMessage("Ism bo'sh bo'lishi mumkin emas.")
            .MaximumLength(50).WithMessage("Ism maksimal 50 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.RegisterDto.LastName)
            .NotEmpty().WithMessage("Familiya bo'sh bo'lishi mumkin emas.")
            .MaximumLength(50).WithMessage("Familiya maksimal 50 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.RegisterDto.MiddleName)
            .MaximumLength(50).WithMessage("Otasining ismi maksimal 50 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.RegisterDto.Email)
            .NotEmpty().WithMessage("Email bo'sh bo'lishi mumkin emas.")
            .EmailAddress().WithMessage("Email formati noto'g'ri.");

        RuleFor(x => x.RegisterDto.Password)
            .NotEmpty().WithMessage("Parol bo'sh bo'lishi mumkin emas.")
            .MinimumLength(6).WithMessage("Parol kamida 6 ta belgidan iborat bo'lishi kerak.");

        RuleFor(x => x.RegisterDto.PhoneNumber)
            .NotEmpty().WithMessage("Telefon raqami bo'sh bo'lishi mumkin emas.")
            .Matches(@"^\+998\d{9}$").WithMessage("Telefon raqami '+998' bilan boshlanishi va jami 13 ta raqam bo'lishi kerak.");
    }
}
