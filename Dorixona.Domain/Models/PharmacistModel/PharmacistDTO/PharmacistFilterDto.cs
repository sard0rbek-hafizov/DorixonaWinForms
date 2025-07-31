using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

public class PharmacistFilterDto
{
    // Filtering
    public string? FullName { get; set; }                // Ism bo‘yicha qidirish
    public string? PhoneNumber { get; set; }             // Telefon raqam bo‘yicha
    public Gender? Gender { get; set; }                  // Jinsi bo‘yicha
    public UserStatus? Status { get; set; }              // Holati (Active, Inactive)
    public Guid? PharmacyId { get; set; }                // Qaysi dorixonada ishlaydi
    public bool? IsLicensed { get; set; }                // Litsenziyasi bor yo‘qligi

    // Date range filtering (boshlanish sanasi bo‘yicha)
    [DataType(DataType.Date)]
    public DateTime? StartDateFrom { get; set; }

    [DataType(DataType.Date)]
    public DateTime? StartDateTo { get; set; }

    // Sorting
    public string? SortBy { get; set; } = "FullName";    // Nima bo‘yicha saralash
    public bool Descending { get; set; } = false;        // Kamayish tartibida

    // Pagination
    [Range(1, int.MaxValue, ErrorMessage = "Page number must be at least 1.")]
    public int PageNumber { get; set; } = 1;

    [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
    public int PageSize { get; set; } = 20;
}