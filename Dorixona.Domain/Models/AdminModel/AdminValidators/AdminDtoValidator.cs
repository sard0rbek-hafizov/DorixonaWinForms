using Dorixona.Domain.Models.AdminModel.AdminDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.AdminModel.AdminValidators;

public class AdminDtoValidator : AbstractValidator<AdminDto>
{
    public AdminDtoValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.PhoneNumber).MaximumLength(15);
        RuleFor(x => x.Role).NotEmpty();
        RuleFor(x => x.Status).NotEmpty();
    }
}
