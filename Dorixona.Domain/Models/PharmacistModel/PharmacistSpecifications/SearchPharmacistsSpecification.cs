using Ardalis.Specification;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistSpecifications;

public class SearchPharmacistsSpecification : PharmacistSpecification
{
    public SearchPharmacistsSpecification(string keyword)
    {
        keyword = keyword.ToLower();

        Query.Where(p =>
            (p.User != null && (
                p.User.FirstName.ToLower().Contains(keyword) ||
                p.User.LastName.ToLower().Contains(keyword) ||
                p.User.Email.ToLower().Contains(keyword)))
            ||
            (p.Certification != null && p.Certification.ToLower().Contains(keyword))
        );
    }
}