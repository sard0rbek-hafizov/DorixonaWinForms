using Dorixona.Domain.Models.UsrModel.UserDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.UsrModel.UserValidators;
public class UpdateUserValidator : AbstractValidator<UserUpdateDto>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.MiddleName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.PhoneNumber).MaximumLength(20).When(x => !string.IsNullOrEmpty(x.PhoneNumber));
    }
}
