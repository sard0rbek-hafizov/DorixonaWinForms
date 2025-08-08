using Dorixona.Application.Features.Auth.Commands;
using FluentValidation;

namespace Dorixona.Application.Validators.Auth;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email bo'sh bo'lishi mumkin emas.")
            .EmailAddress().WithMessage("Email formati noto'g'ri.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Parol bo'sh bo'lishi mumkin emas.")
            .MinimumLength(6).WithMessage("Parol kamida 6 ta belgidan iborat bo'lishi kerak.");
    }
}
