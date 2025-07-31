using Dorixona.Domain.Models.AdminModel.AdminDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.AdminModel.AdminValidators;

public class AdminCreateDtoValidator : AbstractValidator<AdminCreateDto>
{
    public AdminCreateDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId bo'sh bo'lmasligi kerak.");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Izoh 500 belgidan oshmasligi kerak.");
    }
}
