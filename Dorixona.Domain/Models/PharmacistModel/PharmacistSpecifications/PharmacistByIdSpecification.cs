using Ardalis.Specification;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistSpecifications;

public class PharmacistByIdSpecification : PharmacistSpecification
{
    public PharmacistByIdSpecification(Guid pharmacistId)
    {
        Query.Where(p => p.Id == pharmacistId);
    }
}
