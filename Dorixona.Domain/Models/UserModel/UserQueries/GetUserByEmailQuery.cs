namespace Dorixona.Domain.Models.UserModel.UserQueries;
public class GetUserByEmailQuery
{
    public string Email { get; set; }

    public GetUserByEmailQuery(string email)
    {
        Email = email;
    }
}