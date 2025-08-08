using Dorixona.Application.Features.Pharmacies.Queries;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Handlers;

public class GetPharmacyByIdHandler : IRequestHandler<GetPharmacyByIdQuery, PharmacyDto?>
{
    private readonly IPharmacyQueryService _queryService;

    public GetPharmacyByIdHandler(IPharmacyQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<PharmacyDto?> Handle(GetPharmacyByIdQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetByIdAsync(request.PharmacyId);
    }
}
