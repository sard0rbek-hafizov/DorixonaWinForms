using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Queries;

public class ListPharmacistsQuery : IRequest<IReadOnlyList<PharmacistListDto>>
{
}
