using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.OrderModel.Entities;

namespace Dorixona.Domain.Models.PatientModel.PatientSpecifications
{
    public class PatientOrderHistorySpecification : BaseSpecification<Order>
    {
        public PatientOrderHistorySpecification(Guid patientId)
            : base(x => x.PatientId == patientId && x.Status == OrderStatus.Completed)
        {
            AddInclude(x => x.Pill);
            AddOrderByDescending(x => x.OrderedAt);
        }
    }
}
