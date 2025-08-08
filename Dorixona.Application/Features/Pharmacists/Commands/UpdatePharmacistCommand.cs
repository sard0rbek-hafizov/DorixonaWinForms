using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Commands;

public class UpdatePharmacistCommand : IRequest<bool>
{
    public PharmacistUpdateDto Dto { get; set; }

    public UpdatePharmacistCommand(PharmacistUpdateDto dto)
    {
        Dto = dto;
    }
}
