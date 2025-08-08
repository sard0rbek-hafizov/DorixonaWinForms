using Dorixona.Application.Features.Pharmacies.Queries;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Handlers;

public class FilterPharmaciesHandler : IRequestHandler<FilterPharmaciesQuery, List<PharmacyDto>>
{
    private readonly IPharmacyQueryService _queryService;

    public FilterPharmaciesHandler(IPharmacyQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<List<PharmacyDto>> Handle(FilterPharmaciesQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.FilterAsync(request.Filter);
    }
}
