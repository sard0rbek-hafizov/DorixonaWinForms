using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PatientModel.PatientDTO;

public class PatientChangePasswordDto
{
    [Required]
    public string CurrentPassword { get; set; } = default!;

    [Required]
    [MinLength(6)]
    public string NewPassword { get; set; } = default!;

    [Compare("NewPassword", ErrorMessage = "Yangi parollar mos emas.")]
    public string ConfirmPassword { get; set; } = default!;
}
