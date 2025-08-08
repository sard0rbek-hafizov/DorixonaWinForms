using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;
using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using Dorixona.Domain.Models.PharmacistModel.PharmacistEntities;
using Mapster;

namespace Dorixona.Application.Services.Pharmacists;

public class PharmacistService : IPharmacistService
{
    private readonly IPharmacistRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public PharmacistService(IPharmacistRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<PharmacistDto>> GetAllAsync()
    {
        var pharmacists = await _repository.GetAllAsync();
        return pharmacists.Adapt<IEnumerable<PharmacistDto>>();
    }

    public async Task<PharmacistDto?> GetByIdAsync(Guid id)
    {
        var pharmacist = await _repository.GetByIdAsync(id);
        return pharmacist?.Adapt<PharmacistDto>();
    }

    public async Task<Result<PharmacistDto>> CreateAsync(PharmacistCreateDto dto)
    {
        if (await _repository.ExistsAsync(dto.UserId))
        {
            return Result<PharmacistDto>.Failure(Error.Conflict("This user is already assigned as a pharmacist."));
        }

        var pharmacist = dto.Adapt<Pharmacist>();
        pharmacist.Id = Guid.NewGuid();

        await _repository.AddAsync(pharmacist);
        await _unitOfWork.SaveChangesAsync();

        var resultDto = pharmacist.Adapt<PharmacistDto>();
        return Result<PharmacistDto>.Success(resultDto);
    }

    public async Task<Result<PharmacistDto>> UpdateAsync(Guid id, PharmacistUpdateDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
        {
            return Result<PharmacistDto>.Failure(Error.NotFound("Pharmacist", id));
        }

        dto.Adapt(existing); // update existing entity with new values

        await _repository.UpdateAsync(existing);
        await _unitOfWork.SaveChangesAsync();

        var resultDto = existing.Adapt<PharmacistDto>();
        return Result<PharmacistDto>.Success(resultDto);
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
        {
            return Result.Failure(Error.NotFound("Pharmacist", id));
        }

        await _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
