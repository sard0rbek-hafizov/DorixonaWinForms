using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PatientModel.PatientEntities;
using Dorixona.Domain.Models.PharmacyModel.Entities;
using Dorixona.Domain.Models.PillsModel.PillEntities;
using Dorixona.Domain.Models.UserModel.UserEntities;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistEntities;

public class Pharmacist : BaseParams
{
    [Required]
    public Guid UserId { get; set; } // FK: User

    [Required]
    public Guid PharmacyId { get; set; } // FK: Pharmacy

    public string? Certification { get; set; } // Diplom, sertifikat info (optional)

    public bool IsLicensed { get; set; } = true; // Litsenziyasi bor yoki yo‘qligi

    public DateTime StartDate { get; set; } = DateTime.UtcNow; // Ish boshlagan vaqti

    public bool IsActive { get; set; } = true; // Faolligi (soft delete yoki bloklash uchun)

    // Navigation properties
    public User? User { get; set; } // Bog‘liq foydalanuvchi
    public Pharmacy? Pharmacy { get; set; } // Dorixona

    // Dorilar (faqat shu pharmacist boshqarayotganlar)
    public ICollection<Pill> Pills { get; set; } = new List<Pill>();

    // Ushbu pharmacist ishlagan bemorlar (diagnostika qilgan, buyurtmalar qabul qilgan)
    public ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
