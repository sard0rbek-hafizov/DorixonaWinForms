using Dorixona.Domain.Models.OrderModel.Entities;

namespace Dorixona.Domain.Models.PatientModel.IPatientRepositories;

public interface IPatientOrderHistoryService
{
    Task<IEnumerable<Order>> GetCompletedOrdersAsync(Guid patientId);
    Task<IEnumerable<Order>> GetCancelledOrdersAsync(Guid patientId);
    Task<IEnumerable<Order>> GetAllHistoryAsync(Guid patientId);
}
