using Dorixona.Domain.Models.UsrModel.UserDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.UsrModel.UserValidators;
public class CreateUserValidator : AbstractValidator<UserCreateDto>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.MiddleName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}
