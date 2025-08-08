using Dorixona.Application.Features.Admins.Commands;
using Dorixona.Domain.Models.AdminModel.AdminValidators;
using FluentValidation;

namespace Dorixona.Application.Validators.Admins;

public class AdminCreateCommandValidator : AbstractValidator<CreateAdminCommand>
{
    public AdminCreateCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull().SetValidator(new AdminCreateDtoValidator());
    }
}
