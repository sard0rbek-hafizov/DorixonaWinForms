using Dorixona.Domain.Models.AdminModel.AdminDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.AdminModel.AdminValidators;

public class AdminDetailsDtoValidator : AbstractValidator<AdminDetailsDto>
{
    public AdminDetailsDtoValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ism majburiy.")
            .Length(2, 50);

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Familiya majburiy.")
            .Length(2, 50);

        RuleFor(x => x.Email)
            .NotEmpty().EmailAddress();

        RuleFor(x => x.PhoneNumber)
            .Length(7, 13).When(x => !string.IsNullOrEmpty(x.PhoneNumber));

        RuleFor(x => x.LastLoginIP)
            .MaximumLength(45);
    }
}
