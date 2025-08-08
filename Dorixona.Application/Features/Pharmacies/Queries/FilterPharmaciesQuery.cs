using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Queries;

public class FilterPharmaciesQuery : IRequest<List<PharmacyDto>>
{
    public FilterPharmacyDto Filter { get; set; }

    public FilterPharmaciesQuery(FilterPharmacyDto filter)
    {
        Filter = filter;
    }
}