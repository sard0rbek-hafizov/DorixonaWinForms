using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Commands;

public class UpdatePharmacyCommand : IRequest<bool>
{
    public UpdatePharmacyDto Dto { get; }

    public UpdatePharmacyCommand(UpdatePharmacyDto dto)
    {
        Dto = dto;
    }
}