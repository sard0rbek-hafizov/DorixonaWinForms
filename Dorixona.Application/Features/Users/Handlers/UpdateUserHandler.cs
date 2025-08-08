using Dorixona.Application.Features.Users.Commands;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.UserModel.UserRepositories;

namespace Dorixona.Application.Features.Users.Handlers;

public class UpdateUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IUserValidator _userValidator;

    public UpdateUserHandler(IUserRepository userRepository, IUserValidator userValidator)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
    }

    public async Task<Result<bool>> HandleAsync(UpdateUserCommand command)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);
        if (user is null)
            return Result<bool>.Failure(Error.Conflict("Foydalanuvchi topilmadi."));

        user.FirstName = command.UserDto.FirstName;
        user.LastName = command.UserDto.LastName;
        user.MiddleName = command.UserDto.MiddleName;
        user.PhoneNumber = command.UserDto.PhoneNumber;
        user.ProfileImageUrl = command.UserDto.ProfileImage;
        user.Gender = command.UserDto.Gender;
        user.Status = command.UserDto.Status;

        var validationResult = await _userValidator.ValidateUpdateAsync(user);
        if (!validationResult.IsSuccess)
            return Result<bool>.Failure(validationResult.Error);

        await _userRepository.UpdateAsync(user);
        return Result<bool>.Success(true);
    }
}
