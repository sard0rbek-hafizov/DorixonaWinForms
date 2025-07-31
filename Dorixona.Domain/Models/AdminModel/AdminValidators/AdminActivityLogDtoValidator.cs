using Dorixona.Domain.Models.AdminModel.AdminDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.AdminModel.AdminValidators;

public class AdminActivityLogDtoValidator : AbstractValidator<AdminActivityLogDto>
{
    public AdminActivityLogDtoValidator()
    {
        RuleFor(x => x.AdminId).NotEmpty();
        RuleFor(x => x.ActionType)
            .NotEmpty()
            .MaximumLength(100);
        RuleFor(x => x.Description)
            .MaximumLength(500);
        RuleFor(x => x.PerformedAt)
            .LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(x => x.PerformedBy)
            .MaximumLength(50);
    }
}
