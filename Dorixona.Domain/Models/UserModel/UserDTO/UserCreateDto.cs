using System.ComponentModel.DataAnnotations;
using Dorixona.Domain.Enums;
using Dorixona.Domain.CustomAttributes;

namespace Dorixona.Domain.Models.UsrModel.UserDTO;

public class UserCreateDto
{
    [Required(ErrorMessage = "Ism majburiy.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Ism 2 dan 50 gacha belgidan iborat bo'lishi kerak.")]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Familiya majburiy.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Familiya 2 dan 50 gacha belgidan iborat bo'lishi kerak.")]
    public string LastName { get; set; } = default!;

    [StringLength(50, ErrorMessage = "Otasining ismi 50 belgidan oshmasligi kerak.")]
    public string MiddleName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email majburiy.")]
    [EmailAddress(ErrorMessage = "Email formati noto‘g‘ri.")]
    [EmailValidation]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Parol majburiy.")]
    [PasswordValidation]
    public string Password { get; set; } = default!;

    [EnumDataType(typeof(Gender), ErrorMessage = "Jins noto‘g‘ri.")]
    public Gender? Gender { get; set; }

    [Phone(ErrorMessage = "Telefon raqami noto‘g‘ri formatda.")]
    [StringLength(13, ErrorMessage = "Telefon raqami maksimal 13 ta belgidan iborat bo'lishi kerak.")]
    public string? PhoneNumber { get; set; }

    [EnumDataType(typeof(Role), ErrorMessage = "Foydalanuvchi roli noto‘g‘ri.")]
    public Role Role { get; set; } = Role.Patient;
}
