using Dorixona.Domain.Models.UsrModel.UserDTO;

namespace Dorixona.Application.Features.Users.Commands;

public class CreateUserCommand
{
    public UserCreateDto UserDto { get; set; } = default!;
}


