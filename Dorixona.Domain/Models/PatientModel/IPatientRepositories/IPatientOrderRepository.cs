using Dorixona.Domain.Models.OrderModel.Entities;

namespace Dorixona.Domain.Models.PatientModel.IPatientRepositories;

public interface IPatientOrderRepository
{
    Task<IEnumerable<Order>> GetOrdersByPatientIdAsync(Guid patientId);
    Task AddOrderAsync(Order order);
    Task<Order?> GetOrderByIdAsync(Guid orderId);
    Task CancelOrderAsync(Guid orderId);
}
