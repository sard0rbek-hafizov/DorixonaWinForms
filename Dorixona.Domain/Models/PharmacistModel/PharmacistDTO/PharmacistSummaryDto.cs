using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

public class PharmacistSummaryDto
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Ism majburiy")]
    [MaxLength(50, ErrorMessage = "Ism 50 ta belgidan oshmasligi kerak")]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Familiya majburiy")]
    [MaxLength(50, ErrorMessage = "Familiya 50 ta belgidan oshmasligi kerak")]
    public string LastName { get; set; } = default!;

    [Required(ErrorMessage = "Mutaxassislik majburiy")]
    [MaxLength(100, ErrorMessage = "Mutaxassislik 100 ta belgidan oshmasligi kerak")]
    public string Specialization { get; set; } = default!;

    public UserStatus Status { get; set; }

    public Guid PharmacyId { get; set; }

    [MaxLength(100, ErrorMessage = "Dorixona nomi 100 ta belgidan oshmasligi kerak")]
    public string PharmacyName { get; set; } = default!;
}
