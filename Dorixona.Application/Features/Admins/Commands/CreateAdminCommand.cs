using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;
using MediatR;

namespace Dorixona.Application.Features.Admins.Commands;

public class CreateAdminCommand : IRequest<Result<Guid>>
{
    public AdminCreateDto Dto { get; }

    public CreateAdminCommand(AdminCreateDto dto)
    {
        Dto = dto;
    }
}

public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, Result<Guid>>
{
    private readonly IAdminRepository _adminRepository;
    private readonly IAdminValidator _adminValidator;
    private readonly IAdminMapper _adminMapper;

    public CreateAdminCommandHandler(
        IAdminRepository adminRepository,
        IAdminValidator adminValidator,
        IAdminMapper adminMapper)
    {
        _adminRepository = adminRepository;
        _adminValidator = adminValidator;
        _adminMapper = adminMapper;
    }

    public async Task<Result<Guid>> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        // Check if user is already admin
        if (await _adminValidator.IsUserAlreadyAdminAsync(dto.UserId))
        {
            return Result<Guid>.Failure(Error.Conflict("Bu foydalanuvchi allaqachon admin."));
        }

        var admin = _adminMapper.MapFromCreateDto(dto);

        await _adminRepository.CreateAsync(admin);

        return Result<Guid>.Success(admin.Id);
    }
}
