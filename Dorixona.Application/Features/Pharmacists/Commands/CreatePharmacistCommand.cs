using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Commands;

public class CreatePharmacistCommand : IRequest<bool>
{
    public PharmacistCreateDto Dto { get; set; }

    public CreatePharmacistCommand(PharmacistCreateDto dto)
    {
        Dto = dto;
    }
}