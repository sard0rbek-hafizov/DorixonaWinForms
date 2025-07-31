using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.UserModel.UserQueries;
public class GetFilteredUsersQuery
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public Role? Role { get; set; }
    public UserStatus? Status { get; set; }
    public Gender? Gender { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
