using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PatientModel.PatientDTO;

public class PatientStatusUpdateDto
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public UserStatus Status { get; set; }

    public bool IsDeleted { get; set; }
}
