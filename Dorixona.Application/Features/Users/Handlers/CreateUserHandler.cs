using AutoMapper;
using Dorixona.Application.Features.Users.Commands;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UserModel.UserRepositories;

namespace Dorixona.Application.Features.Users.Handlers;

public class CreateUserHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IUserValidator _userValidator;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUserRepository userRepository, IUserValidator userValidator, IMapper mapper)
    {
        _userRepository = userRepository;
        _userValidator = userValidator;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> HandleAsync(CreateUserCommand command)
    {
        var user = new User(
            command.UserDto.FirstName,
            command.UserDto.LastName,
            command.UserDto.MiddleName,
            command.UserDto.Email,
            command.UserDto.Password,
            command.UserDto.PhoneNumber
        )
        {
            Gender = command.UserDto.Gender,
            Role = command.UserDto.Role
        };

        var validationResult = await _userValidator.ValidateCreateAsync(user);
        if (!validationResult.IsSuccess)
            return Result<Guid>.Failure(validationResult.Error);

        await _userRepository.AddAsync(user);
        return Result<Guid>.Success(user.Id);
    }
}
