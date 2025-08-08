namespace Dorixona.Application.Features.Users.Queries;

public class GetUserByIdQuery
{
    public Guid Id { get; set; }

    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
}


