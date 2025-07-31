using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.OrderModel.Entities;

namespace Dorixona.Domain.Models.PatientModel.PatientSpecifications
{
    public class PatientOwnOrdersSpecification : BaseSpecification<Order>
    {
        public PatientOwnOrdersSpecification(Guid patientId) : base(x => x.PatientId == patientId)
        {
            AddInclude(x => x.Pill);
            AddOrderByDescending(x => x.OrderedAt);
        }
    }
}
