using Ardalis.Specification;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistSpecifications;

public class PharmacistsByPharmacyIdSpecification : PharmacistSpecification
{
    public PharmacistsByPharmacyIdSpecification(Guid pharmacyId)
    {
        Query.Where(p => p.PharmacyId == pharmacyId);
    }
}
