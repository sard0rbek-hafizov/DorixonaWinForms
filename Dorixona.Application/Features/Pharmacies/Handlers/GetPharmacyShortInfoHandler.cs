using Dorixona.Application.Features.Pharmacies.Queries;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Handlers;

public class GetPharmacyShortInfoHandler : IRequestHandler<GetPharmacyShortInfoQuery, PharmacyShortDto?>
{
    private readonly IPharmacyQueryService _queryService;

    public GetPharmacyShortInfoHandler(IPharmacyQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<PharmacyShortDto?> Handle(GetPharmacyShortInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await _queryService.GetByIdAsync(request.PharmacyId);
        if (result is null) return null;

        return new PharmacyShortDto
        {
            Id = result.Id,
            Name = result.Name,
            Address = result.Address,
            PhoneNumber = result.PhoneNumber
        };
    }
}
