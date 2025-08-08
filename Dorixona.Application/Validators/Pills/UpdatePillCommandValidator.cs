using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Models.PillsModel.PillValidators;
using FluentValidation;

namespace Dorixona.Application.Validators.Pills;

public class UpdatePillCommandValidator : AbstractValidator<UpdatePillDto>
{
    public UpdatePillCommandValidator()
    {
        Include(new UpdatePillDtoValidator());
    }
}