using Dorixona.Domain.Models.PharmacyModel.Entities;
using Dorixona.Domain.Models.PillsModel.PillEntities;

namespace Dorixona.Domain.Models.PillsModel.IPillRepositories;
public class PharmacyPill
{
    public Guid PharmacyId { get; set; }
    public Pharmacy Pharmacy { get; set; } = default!;

    public Guid PillId { get; set; }
    public Pill Pill { get; set; } = default!;

    public int Quantity { get; set; } // Shu dorixonada nechta bor
}
