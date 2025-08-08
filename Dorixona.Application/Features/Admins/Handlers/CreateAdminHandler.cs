using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;

namespace Dorixona.Application.Features.Admins.Handlers;

public class CreateAdminHandler
{
    private readonly IAdminRepository _repository;
    private readonly IAdminValidator _validator;
    private readonly IAdminMapper _mapper;

    public CreateAdminHandler(IAdminRepository repository, IAdminValidator validator, IAdminMapper mapper)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<Result<Guid>> HandleAsync(AdminCreateDto dto)
    {
        if (await _validator.IsUserAlreadyAdminAsync(dto.UserId))
            return Result<Guid>.Failure(Error.Conflict("User already admin"));

        var admin = _mapper.MapFromCreateDto(dto);
        await _repository.CreateAsync(admin);

        return Result<Guid>.Success(admin.Id);
    }
}
