using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.UsrModel.UserDTO;

public class UserFilterDto
{
    public string? FullName { get; set; }
    public string? Email { get; set; }

    public Role? Role { get; set; }
    public UserStatus? Status { get; set; }
    public Gender? Gender { get; set; }

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
