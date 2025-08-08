using Dorixona.Application.Features.Pharmacies.Queries;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Handlers;

public class GetPharmacyWithPillsHandler : IRequestHandler<GetPharmacyWithPillsQuery, PharmacyDto?>
{
    private readonly IPharmacyQueryService _queryService;

    public GetPharmacyWithPillsHandler(IPharmacyQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<PharmacyDto?> Handle(GetPharmacyWithPillsQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetByIdAsync(request.PharmacyId); // Assume Pills are included
    }
}
