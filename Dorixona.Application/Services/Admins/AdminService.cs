using AutoMapper;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;

namespace Dorixona.Application.Services.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _adminRepository;
    private readonly IMapper _mapper;

    public AdminService(IAdminRepository adminRepository, IMapper mapper)
    {
        _adminRepository = adminRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AdminDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var admins = await _adminRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<AdminDto>>(admins);
    }

    public async Task<AdminDto?> GetByIdAsync(Guid adminId, CancellationToken cancellationToken = default)
    {
        var admin = await _adminRepository.GetByIdAsync(adminId);
        return admin is null ? null : _mapper.Map<AdminDto>(admin);
    }

    public async Task<Result<AdminDto>> CreateAsync(AdminCreateDto dto, CancellationToken cancellationToken = default)
    {
        var admin = _mapper.Map<Admin>(dto);
        admin.Id = Guid.NewGuid();
        admin.CreateDate = DateTime.UtcNow;

        await _adminRepository.CreateAsync(admin);

        var resultDto = _mapper.Map<AdminDto>(admin);
        return Result<AdminDto>.Success(resultDto);
    }

    public async Task<Result<AdminDto>> UpdateAsync(Guid adminId, AdminUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var existing = await _adminRepository.GetByIdAsync(adminId);
        if (existing is null)
            return Result<AdminDto>.Failure(Error.NotFound("Admin", adminId));

        _mapper.Map(dto, existing);
        await _adminRepository.UpdateAsync(existing);

        var updatedDto = _mapper.Map<AdminDto>(existing);
        return Result<AdminDto>.Success(updatedDto);
    }

    public async Task<Result> DeleteAsync(Guid adminId, CancellationToken cancellationToken = default)
    {
        var exists = await _adminRepository.ExistsAsync(adminId);
        if (!exists)
            return Result.Failure(Error.NotFound("Admin", adminId));

        await _adminRepository.DeleteAsync(adminId);
        return Result.Success();
    }
}