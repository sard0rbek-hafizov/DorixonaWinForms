namespace Dorixona.Domain.Models.UserModel.UserQueries;
public class GetUserByIdQuery
{
    public Guid Id { get; set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}
