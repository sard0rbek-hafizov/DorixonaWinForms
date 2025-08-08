using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Commands;

public class CreatePharmacyCommand : IRequest<bool>
{
    public CreatePharmacyDto Dto { get; }

    public CreatePharmacyCommand(CreatePharmacyDto dto)
    {
        Dto = dto;
    }
}
