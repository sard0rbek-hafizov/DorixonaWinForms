namespace Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

public class PharmacistListDto
{
    public Guid Id { get; set; }                      // Pharmacist ID

    public string FullName { get; set; } = default!;  // F.I.Sh (User dan olinadi)

    public string PhoneNumber { get; set; } = default!; // Telefon (User dan olinadi)

    public string Email { get; set; } = default!;     // Email (User dan olinadi)

    public string PharmacyName { get; set; } = default!; // Dorixona nomi

    public bool IsLicensed { get; set; }              // Litsenziya holati

    public DateTime StartDate { get; set; }           // Ish boshlagan sana

    public bool IsActive { get; set; }                // Faollik holati
}
