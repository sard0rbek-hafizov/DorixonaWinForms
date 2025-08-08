using Dorixona.Application.Features.Pharmacists.Queries;
using Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;
using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Handlers;

public class GetPharmacistByIdHandler : IRequestHandler<GetPharmacistByIdQuery, PharmacistDetailsDto?>
{
    private readonly IPharmacistQueryService _queryService;

    public GetPharmacistByIdHandler(IPharmacistQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<PharmacistDetailsDto?> Handle(GetPharmacistByIdQuery request, CancellationToken cancellationToken)
    {
        return await _queryService.GetDetailsByIdAsync(request.Id);
    }
}

