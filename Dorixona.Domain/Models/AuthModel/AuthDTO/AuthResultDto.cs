namespace Dorixona.Domain.Models.AuthModel.AuthDTO;

public class AuthResultDto
{
    public Guid UserId { get; set; }
    public string FullName { get; set; } = default!;
    public string Role { get; set; } = default!;
    public TokenDto Token { get; set; } = default!;
}
