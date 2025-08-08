using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;

namespace Dorixona.Application.Features.Admins.Handlers;

public class UpdateAdminHandler
{
    private readonly IAdminRepository _repository;
    private readonly IAdminValidator _validator;
    private readonly IAdminMapper _mapper;

    public UpdateAdminHandler(IAdminRepository repository, IAdminValidator validator, IAdminMapper mapper)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<Result> HandleAsync(AdminUpdateDto dto)
    {
        if (!await _validator.ExistsAsync(dto.Id))
            return Result.Failure(Error.NotFound("Admin", dto.Id));

        if (!await _validator.IsValidForUpdateAsync(dto.Id, dto.UserId))
            return Result.Failure(Error.Conflict("UserId already used by another admin"));

        var admin = await _repository.GetByIdAsync(dto.Id);
        if (admin is null)
            return Result.Failure(Error.NotFound("Admin", dto.Id));

        _mapper.MapFromUpdateDto(admin, dto);
        await _repository.UpdateAsync(admin);

        return Result.Success();
    }
}
