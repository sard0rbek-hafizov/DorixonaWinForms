using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.OrderModel.Entities;

namespace Dorixona.Domain.Models.PatientModel.PatientSpecifications;

public class PatientAvailablePillsSpecification : BaseSpecification<Order>
{
    public PatientAvailablePillsSpecification()
        : base(x => x.Pill != null && x.Pill.StockQuantity > 0 && x.Pill.ExpiryDate > DateTime.UtcNow)
    {
        AddInclude(x => x.Pill);
    }
}
