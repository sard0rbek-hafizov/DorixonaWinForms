using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminDashboardStatsDto
{
    [Range(0, int.MaxValue, ErrorMessage = "Foydalanuvchilar soni 0 dan kam bo'lishi mumkin emas.")]
    public int TotalUsers { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Faol foydalanuvchilar soni 0 dan kam bo'lishi mumkin emas.")]
    public int ActiveUsers { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Farmatsevtlar soni 0 dan kam bo'lishi mumkin emas.")]
    public int TotalPharmacists { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Bemorlar soni 0 dan kam bo'lishi mumkin emas.")]
    public int TotalPatients { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Dorilar soni 0 dan kam bo'lishi mumkin emas.")]
    public int TotalPills { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Buyurtmalar soni 0 dan kam bo'lishi mumkin emas.")]
    public int TotalOrders { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Bugungi buyurtmalar soni 0 dan kam bo'lishi mumkin emas.")]
    public int OrdersToday { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "To‘langan buyurtmalar soni 0 dan kam bo'lishi mumkin emas.")]
    public int PaidOrders { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Dorixonalar soni 0 dan kam bo'lishi mumkin emas.")]
    public int TotalPharmacies { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Umumiy daromad 0 dan kam bo'lishi mumkin emas.")]
    public decimal TotalRevenue { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Bugungi daromad 0 dan kam bo'lishi mumkin emas.")]
    public decimal TodayRevenue { get; set; }
}
