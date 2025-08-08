using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UserModel.UserRepositories;
using Dorixona.Domain.Models.UsrModel.UserDTO;
using Mapster;

namespace Dorixona.Application.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Adapt<IEnumerable<UserDto>>();
    }

    public async Task<UserDto?> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return user?.Adapt<UserDto>();
    }

    public async Task<Result<UserDto>> CreateAsync(UserCreateDto dto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser is not null)
        {
            return Result<UserDto>.Failure(Error.Conflict("Email allaqachon mavjud."));
        }

        var user = dto.Adapt<User>();
        user.PasswordHash = HashPassword(dto.Password);
        user.CreateDate = DateTime.UtcNow;
        user.UpdateDate = DateTime.UtcNow;
        user.DeleteDate = null;
        user.IsDelete = false;

        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return Result<UserDto>.Success(user.Adapt<UserDto>());
    }

    public async Task<Result<UserDto>> UpdateAsync(Guid id, UserUpdateDto dto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
        {
            return Result<UserDto>.Failure(Error.NotFound("User", id));
        }

        dto.Adapt(user);
        user.UpdateDate = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return Result<UserDto>.Success(user.Adapt<UserDto>());
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user is null)
        {
            return Result.Failure(Error.NotFound("User", id));
        }

        user.IsDelete = true;
        user.DeleteDate = DateTime.UtcNow;
        user.UpdateDate = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
    private string HashPassword(string password)
    {
        // TODO: Replace with secure password hashing
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }
}
