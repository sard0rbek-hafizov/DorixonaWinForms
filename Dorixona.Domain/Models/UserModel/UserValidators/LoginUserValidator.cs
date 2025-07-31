using Dorixona.Domain.Models.UsrModel.UserDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.UsrModel.UserValidators;
public class LoginUserValidator : AbstractValidator<UserLoginDto>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}
