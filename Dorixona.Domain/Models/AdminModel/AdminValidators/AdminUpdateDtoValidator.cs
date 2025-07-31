using Dorixona.Domain.Models.AdminModel.AdminDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.AdminModel.AdminValidators;

public class AdminUpdateDtoValidator : AbstractValidator<AdminUpdateDto>
{
    public AdminUpdateDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Admin ID majburiy.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID majburiy.");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Izoh 500 belgidan oshmasligi kerak.");
    }
}