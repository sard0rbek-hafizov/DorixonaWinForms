using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminDetailsDto
{
    [Required]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Ism majburiy.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Ism 2-50 ta belgidan iborat bo‘lishi kerak.")]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Familiya majburiy.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Familiya 2-50 ta belgidan iborat bo‘lishi kerak.")]
    public string LastName { get; set; } = default!;

    [Required(ErrorMessage = "Email majburiy.")]
    [EmailAddress(ErrorMessage = "Email formati noto‘g‘ri.")]
    public string Email { get; set; } = default!;

    [Phone(ErrorMessage = "Telefon raqam formati noto‘g‘ri.")]
    [StringLength(13, MinimumLength = 7, ErrorMessage = "Telefon raqam uzunligi 7-13 belgidan iborat bo‘lishi kerak.")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Role majburiy.")]
    [EnumDataType(typeof(Role), ErrorMessage = "Noto‘g‘ri Role tipi.")]
    public Role Role { get; set; }

    [EnumDataType(typeof(UserStatus), ErrorMessage = "Noto‘g‘ri Status tipi.")]
    public UserStatus Status { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? LastLoginAt { get; set; }

    [StringLength(45, ErrorMessage = "IP address maksimal 45 belgidan iborat bo‘lishi kerak.")]
    public string? LastLoginIP { get; set; }
}