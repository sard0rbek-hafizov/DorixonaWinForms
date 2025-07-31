namespace Dorixona.Domain.Models.UserModel.UserQueries;
public class GetAllUsersQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}