using Ardalis.Specification;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistSpecifications;

public class PharmacistPaginationSpecification : PharmacistSpecification
{
    public PharmacistPaginationSpecification(int skip, int take)
    {
        Query.Skip(skip).Take(take);
    }
}