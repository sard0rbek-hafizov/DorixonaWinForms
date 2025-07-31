using Dorixona.Application.DTOs.Pills;
namespace Dorixona.Domain.Models.PillsModel.PillDTO;
public class PharmacyWithPillsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public bool IsActive { get; set; }
    public IReadOnlyList<PillDto> Pills { get; set; } = new List<PillDto>();
}
