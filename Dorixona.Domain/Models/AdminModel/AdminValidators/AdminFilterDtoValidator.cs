﻿using Dorixona.Domain.Models.AdminModel.AdminDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.AdminModel.AdminValidators;

public class AdminFilterDtoValidator : AbstractValidator<AdminFilterDto>
{
    public AdminFilterDtoValidator()
    {
        RuleFor(x => x.FirstName).MaximumLength(50);
        RuleFor(x => x.LastName).MaximumLength(50);
        RuleFor(x => x.Email).EmailAddress().MaximumLength(100);
        RuleFor(x => x.PhoneNumber).MaximumLength(15);
        RuleFor(x => x.CreatedFrom).LessThanOrEqualTo(x => x.CreatedTo)
            .When(x => x.CreatedFrom.HasValue && x.CreatedTo.HasValue);
    }
}
