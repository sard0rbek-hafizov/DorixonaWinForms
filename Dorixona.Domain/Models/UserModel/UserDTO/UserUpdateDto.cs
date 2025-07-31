using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.UsrModel.UserDTO;
public class UserUpdateDto
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string MiddleName { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public string? ProfileImage { get; set; }
    public Gender? Gender { get; set; }
    public UserStatus Status { get; set; } = UserStatus.Active;
}
