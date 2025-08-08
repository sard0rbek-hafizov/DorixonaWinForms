using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Commands;

public class DeactivatePharmacistCommand : IRequest<bool>
{
    public Guid PharmacistId { get; set; }

    public DeactivatePharmacistCommand(Guid pharmacistId)
    {
        PharmacistId = pharmacistId;
    }
}
