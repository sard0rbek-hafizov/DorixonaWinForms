using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Commands;

public class DeactivatePharmacyCommand : IRequest<bool>
{
    public Guid PharmacyId { get; }

    public DeactivatePharmacyCommand(Guid pharmacyId)
    {
        PharmacyId = pharmacyId;
    }
}
