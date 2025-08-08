using Dorixona.Domain.Models.OrderModel.Entities;
using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using MediatR;

namespace Dorixona.Application.Features.Patients.Queries;

public class GetPatientOrdersQuery : IRequest<IEnumerable<Order>>
{
    public Guid PatientId { get; set; }

    public class Handler : IRequestHandler<GetPatientOrdersQuery, IEnumerable<Order>>
    {
        private readonly IPatientOrderRepository _orderRepository;

        public Handler(IPatientOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> Handle(GetPatientOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrdersByPatientIdAsync(request.PatientId);
        }
    }
}
