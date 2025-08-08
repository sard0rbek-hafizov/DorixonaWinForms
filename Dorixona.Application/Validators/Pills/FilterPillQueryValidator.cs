using Dorixona.Domain.Models.PillsModel.PillDTO;
using Dorixona.Domain.Models.PillsModel.PillValidators;
using FluentValidation;

namespace Dorixona.Application.Validators.Pills;

public class FilterPillQueryValidator : AbstractValidator<FilterPillDto>
{
    public FilterPillQueryValidator()
    {
        Include(new FilterPillDtoValidator());
    }
}