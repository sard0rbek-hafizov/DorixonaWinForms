using Dorixona.Domain.Models.AdminModel.AdminDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.AdminModel.AdminValidators;

public class AdminPaginationDtoValidator : AbstractValidator<AdminPaginationDto>
{
    public AdminPaginationDtoValidator()
    {
        RuleFor(x => x.PageNumber).GreaterThan(0);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
        RuleFor(x => x.Search).MaximumLength(50);
        RuleFor(x => x.SortBy).MaximumLength(20);
        RuleFor(x => x.SortOrder)
            .Must(value => value == "asc" || value == "desc")
            .When(x => !string.IsNullOrEmpty(x.SortOrder))
            .WithMessage("SortOrder faqat 'asc' yoki 'desc' bo'lishi mumkin.");
    }
}
