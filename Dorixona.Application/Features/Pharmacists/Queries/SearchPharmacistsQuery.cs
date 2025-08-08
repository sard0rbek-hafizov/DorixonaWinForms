using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Queries;

public class SearchPharmacistsQuery : IRequest<IReadOnlyList<PharmacistListDto>>
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string SearchText { get; set; } = string.Empty;

    public SearchPharmacistsQuery(string? name, string? phoneNumber, string? email)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
