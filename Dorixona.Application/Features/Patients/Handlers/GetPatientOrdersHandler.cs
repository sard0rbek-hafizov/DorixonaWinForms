using Dorixona.Domain.Models.OrderModel.Entities;
using Dorixona.Domain.Models.PatientModel.IPatientRepositories;

namespace Dorixona.Application.Features.Patients.Handlers;

public class GetPatientOrdersHandler
{
    private readonly IPatientOrderRepository _orderRepository;

    public GetPatientOrdersHandler(IPatientOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Order>> HandleAsync(Guid patientId)
    {
        return await _orderRepository.GetOrdersByPatientIdAsync(patientId);
    }
}