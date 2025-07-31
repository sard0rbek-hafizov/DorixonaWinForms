using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminFilterDto
{
    [MaxLength(50, ErrorMessage = "Ism 50 belgidan oshmasligi kerak.")]
    public string? FirstName { get; set; }

    [MaxLength(50, ErrorMessage = "Familiya 50 belgidan oshmasligi kerak.")]
    public string? LastName { get; set; }

    [EmailAddress(ErrorMessage = "Email formati noto‘g‘ri.")]
    [MaxLength(100, ErrorMessage = "Email 100 belgidan oshmasligi kerak.")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "Telefon raqam formati noto‘g‘ri.")]
    [MaxLength(15, ErrorMessage = "Telefon raqam 15 belgidan oshmasligi kerak.")]
    public string? PhoneNumber { get; set; }

    public Gender? Gender { get; set; }

    public Role? Role { get; set; }

    public UserStatus? Status { get; set; }

    [DataType(DataType.Date)]
    public DateTime? CreatedFrom { get; set; }

    [DataType(DataType.Date)]
    public DateTime? CreatedTo { get; set; }
}
