using Dorixona.Application.Features.Pharmacists.Queries;
using Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;
using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Handlers;

public class ListPharmacistHandler : IRequestHandler<ListPharmacistsQuery, IReadOnlyList<PharmacistListDto>>
{
    private readonly IPharmacistQueryService _queryService;

    public ListPharmacistHandler(IPharmacistQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<IReadOnlyList<PharmacistListDto>> Handle(ListPharmacistsQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetAllAsync();
    }
}