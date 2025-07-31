using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.UsrModel.UserDTO;

public class ChangePasswordDto
{
    [Required(ErrorMessage = "Hozirgi parol majburiy.")]
    public string CurrentPassword { get; set; } = default!;

    [Required(ErrorMessage = "Yangi parol majburiy.")]
    [MinLength(6, ErrorMessage = "Yangi parol kamida 6 ta belgidan iborat bo‘lishi kerak.")]
    public string NewPassword { get; set; } = default!;

    [Required(ErrorMessage = "Yangi parolni tasdiqlang.")]
    [Compare("NewPassword", ErrorMessage = "Tasdiqlovchi parol yangi parolga mos emas.")]
    public string ConfirmNewPassword { get; set; } = default!;
}
