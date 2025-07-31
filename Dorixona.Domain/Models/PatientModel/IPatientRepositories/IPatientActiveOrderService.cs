using Dorixona.Domain.Models.OrderModel.Entities;

namespace Dorixona.Domain.Models.PatientModel.IPatientRepositories;

public interface IPatientActiveOrderService
{
    Task<IEnumerable<Order>> GetActiveOrdersAsync(Guid patientId);
    Task<Order?> GetCurrentOrderAsync(Guid patientId);
}
