using Ardalis.Specification;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistSpecifications;

public class ActivePharmacistsSpecification : PharmacistSpecification
{
    public ActivePharmacistsSpecification()
    {
        Query.Where(p => p.IsActive && p.IsLicensed);
    }
}