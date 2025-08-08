using Dorixona.Application.Features.Pharmacists.Queries;
using Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;
using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Handlers;

public class SearchPharmacistsHandler : IRequestHandler<SearchPharmacistsQuery, IReadOnlyList<PharmacistListDto>>
{
    private readonly IPharmacistQueryService _queryService;

    public SearchPharmacistsHandler(IPharmacistQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<IReadOnlyList<PharmacistListDto>> Handle(SearchPharmacistsQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.SearchAsync(request.SearchText);
    }
}