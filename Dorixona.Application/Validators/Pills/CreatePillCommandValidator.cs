using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Models.PillsModel.PillValidators;
using FluentValidation;

namespace Dorixona.Application.Validators.Pills;

public class CreatePillCommandValidator : AbstractValidator<CreatePillDto>
{
    public CreatePillCommandValidator()
    {
        Include(new CreatePillDtoValidator());
    }
}