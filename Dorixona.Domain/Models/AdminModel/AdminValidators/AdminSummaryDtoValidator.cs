using Dorixona.Domain.Models.AdminModel.AdminDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.AdminModel.AdminValidators;

public class AdminSummaryDtoValidator : AbstractValidator<AdminSummaryDto>
{
    public AdminSummaryDtoValidator()
    {
        RuleFor(x => x.TotalAdmins).GreaterThanOrEqualTo(0);
        RuleFor(x => x.ActiveAdmins).GreaterThanOrEqualTo(0);
        RuleFor(x => x.BlockedAdmins).GreaterThanOrEqualTo(0);
        RuleFor(x => x.LastCreatedAdmin).NotNull();
    }
}
