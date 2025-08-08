using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Queries;

public class GetPharmacistByIdQuery : IRequest<PharmacistDetailsDto>
{
    public Guid Id { get; set; }

    public GetPharmacistByIdQuery(Guid id)
    {
        Id = id;
    }
}
