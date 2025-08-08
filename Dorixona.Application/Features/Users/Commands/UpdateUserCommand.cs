using Dorixona.Domain.Models.UsrModel.UserDTO;

namespace Dorixona.Application.Features.Users.Commands;

public class UpdateUserCommand
{
    public Guid Id { get; set; }
    public UserUpdateDto UserDto { get; set; } = default!;
}
