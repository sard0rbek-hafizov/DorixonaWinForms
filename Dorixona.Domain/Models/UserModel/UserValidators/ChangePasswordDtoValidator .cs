using Dorixona.Domain.Models.UsrModel.UserDTO;
using FluentValidation;
namespace Dorixona.Domain.Models.UserModel.UserValidators;
public class ChangePasswordDtoValidator : AbstractValidator<ChangePasswordDto>
{
    public ChangePasswordDtoValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .NotEmpty().WithMessage("Hozirgi parol majburiy.");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Yangi parol majburiy.")
            .MinimumLength(6).WithMessage("Yangi parol kamida 6 ta belgidan iborat bo‘lishi kerak.");

        RuleFor(x => x.ConfirmNewPassword)
            .Equal(x => x.NewPassword)
            .WithMessage("Tasdiqlovchi parol yangi parolga mos emas.");
    }
}
