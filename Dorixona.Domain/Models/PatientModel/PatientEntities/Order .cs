using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.PatientModel.PatientEntities;
using Dorixona.Domain.Models.PillsModel.PillEntities;
namespace Dorixona.Domain.Models.OrderModel.Entities;

public class Order : BaseParams
{
    public Guid PatientId { get; set; }                         // FK: Bemor
    public Guid PillId { get; set; }                            // FK: Dori
    public int Quantity { get; set; }                           // Buyurtma soni
    public decimal TotalPrice { get; set; }                     // Umumiy narx
    public OrderStatus Status { get; set; }                     // Order holati
    public PaymentType PaymentType { get; set; }                // To‘lov turi
    public DateTime OrderedAt { get; set; } = DateTime.UtcNow;  // Buyurtma vaqti

    //  Navigatsiya property
    public Pill? Pill { get; set; }
    public Patient? Patient { get; set; }
}
