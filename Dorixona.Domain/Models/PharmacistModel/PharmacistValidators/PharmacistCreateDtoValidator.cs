﻿using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using FluentValidation;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistValidators;

public class PharmacistCreateDtoValidator : AbstractValidator<PharmacistCreateDto>
{
    public PharmacistCreateDtoValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId bo‘sh bo‘lmasligi kerak.");

        RuleFor(x => x.PharmacyId)
            .NotEmpty().WithMessage("PharmacyId bo‘sh bo‘lmasligi kerak.");

        RuleFor(x => x.Certification)
            .MaximumLength(255).WithMessage("Certification 255 belgidan oshmasligi kerak.");

        RuleFor(x => x.StartDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("StartDate hozirgi kundan oldin yoki teng bo‘lishi kerak.");
    }
}
