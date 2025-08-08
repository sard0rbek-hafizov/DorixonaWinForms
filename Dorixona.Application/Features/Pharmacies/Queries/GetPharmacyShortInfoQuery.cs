using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Queries;

public class GetPharmacyShortInfoQuery : IRequest<PharmacyShortDto>
{
    public Guid PharmacyId { get; set; }

    public GetPharmacyShortInfoQuery(Guid pharmacyId)
    {
        PharmacyId = pharmacyId;
    }
}
