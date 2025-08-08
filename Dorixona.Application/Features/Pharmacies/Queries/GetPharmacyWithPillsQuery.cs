using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using Dorixona.Domain.Models.PillsModel.PillDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Queries;

public class GetPharmacyWithPillsQuery : IRequest<PharmacyDto>
{
    public Guid PharmacyId { get; set; }

    public GetPharmacyWithPillsQuery(Guid pharmacyId)
    {
        PharmacyId = pharmacyId;
    }
}
