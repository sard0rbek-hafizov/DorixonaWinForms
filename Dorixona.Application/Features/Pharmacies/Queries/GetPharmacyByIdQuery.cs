using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Queries;

public class GetPharmacyByIdQuery : IRequest<PharmacyDto?>
{
    public Guid PharmacyId { get; set; }

    public GetPharmacyByIdQuery(Guid pharmacyId)
    {
        PharmacyId = pharmacyId;
    }
}
