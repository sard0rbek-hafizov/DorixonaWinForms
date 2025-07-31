using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.OrderModel.Entities;

namespace Dorixona.Domain.Models.PatientModel.PatientSpecifications;

public class PatientActiveOrderSpecification : BaseSpecification<Order>
{
    public PatientActiveOrderSpecification(Guid patientId)
        : base(x => x.PatientId == patientId && x.Status != OrderStatus.Completed && x.Status != OrderStatus.Cancelled)
    {
        AddInclude(x => x.Pill);
        AddOrderByDescending(x => x.OrderedAt);
    }
}
