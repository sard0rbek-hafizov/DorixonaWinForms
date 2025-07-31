using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.OrderModel.Entities;

namespace Dorixona.Domain.Models.PatientModel.PatientSpecifications;

public class PatientSearchPillsSpecification : BaseSpecification<Order>
{
    public PatientSearchPillsSpecification(string keyword)
        : base(x => x.Pill != null && x.Pill.Name.ToLower().Contains(keyword.ToLower()))
    {
        AddInclude(x => x.Pill);
    }
}
