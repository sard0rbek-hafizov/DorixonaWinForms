using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.OrderModel.Entities;
using Dorixona.Domain.Models.PatientModel.PatientEntities;
using Dorixona.Domain.Models.PharmacistModel.PharmacistEntities;
using Dorixona.Domain.Models.PharmacyModel.Entities;
using Dorixona.Domain.Models.PillsModel.PillEntities;
using Dorixona.Domain.Models.UserModel.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminEntities;

public class Admin : BaseParams
{
    [Required]
    public Guid UserId { get; set; }

    public User? User { get; set; } // FK orqali Adminning Useri

    // Admin ko‘rishi mumkin bo‘lgan barcha foydalanuvchilar
    public ICollection<User>? Users { get; set; }

    // Tizimdagi barcha Pharmacistlar
    public ICollection<Pharmacist>? Pharmacists { get; set; }

    // Dorixonalarni nazorat qilish
    public ICollection<Pharmacy>? Pharmacies { get; set; }

    // Dori-darmonlar
    public ICollection<Pill>? Pills { get; set; }

    // Bemorlar (tizimdagi hamma bemorlar)
    public ICollection<Patient>? Patients { get; set; }

    // Buyurtmalarni monitoring qilish
    public ICollection<Order>? Orders { get; set; }

    // Vazifalar yoki tasdiqlar (optional: loglar uchun)
    public string? Notes { get; set; }
}
