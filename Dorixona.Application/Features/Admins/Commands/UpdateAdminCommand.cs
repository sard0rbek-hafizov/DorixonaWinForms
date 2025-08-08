using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;
using MediatR;

namespace Dorixona.Application.Features.Admins.Commands;

public class UpdateAdminCommand : IRequest<Result>
{
    public AdminUpdateDto Dto { get; }

    public UpdateAdminCommand(AdminUpdateDto dto)
    {
        Dto = dto;
    }
}

public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, Result>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IAdminValidator _adminValidator;
    private readonly IAdminMapper _adminMapper;

    public UpdateAdminCommandHandler(
        IAdminRepository adminRepository,
        IAdminValidator adminValidator,
        IAdminMapper adminMapper)
    {
        _adminRepository = adminRepository;
        _adminValidator = adminValidator;
        _adminMapper = adminMapper;
    }

    public async Task<Result> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        var exists = await _adminValidator.ExistsAsync(dto.Id);
        if (!exists)
        {
            return Result.Failure(Error.NotFound("Admin", dto.Id));
        }

        var isValid = await _adminValidator.IsValidForUpdateAsync(dto.Id, dto.UserId);
        if (!isValid)
        {
            return Result.Failure(Error.Conflict("Bunday UserId boshqa adminga tegishli."));
        }

        var admin = await _adminRepository.GetByIdAsync(dto.Id);
        if (admin is null)
        {
            return Result.Failure(Error.NotFound("Admin", dto.Id));
        }

        _adminMapper.MapFromUpdateDto(admin, dto);

        await _adminRepository.UpdateAsync(admin);

        return Result.Success();
    }
}
