using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.PatientModel.PatientDTO;

public class PatientFilterDto
{
    public string? FullName { get; set; }
    public Gender? Gender { get; set; }
    public bool? HasChronicDiseases { get; set; }

    public DateTime? FromBirthDate { get; set; }
    public DateTime? ToBirthDate { get; set; }

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
