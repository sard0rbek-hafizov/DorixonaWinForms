using Ardalis.Specification;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistSpecifications;

public class PharmacistWithPharmacySpecification : PharmacistSpecification
{
    public PharmacistWithPharmacySpecification(Guid pharmacistId)
    {
        Query
            .Include(p => p.Pharmacy)
            .Include(p => p.User)
            .Where(p => p.Id == pharmacistId);
    }
}