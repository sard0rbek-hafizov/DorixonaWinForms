using AutoMapper;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PharmacyModel.Entities;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;

namespace Dorixona.Application.Services.Pharmacies;

public class PharmacyService : IPharmacyService
{
    private readonly IPharmacyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PharmacyService(IPharmacyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<PharmacyDto>> GetAllAsync()
    {
        var pharmacies = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<PharmacyDto>>(pharmacies);
    }

    public async Task<PharmacyDto?> GetByIdAsync(Guid id)
    {
        var pharmacy = await _repository.GetByIdAsync(id);
        return pharmacy is null ? null : _mapper.Map<PharmacyDto>(pharmacy);
    }

    public async Task<Result<PharmacyDto>> CreateAsync(CreatePharmacyDto dto)
    {
        var entity = _mapper.Map<Pharmacy>(dto);
        entity.Id = Guid.NewGuid();
        entity.CreateDate = DateTime.UtcNow;

        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();

        var resultDto = _mapper.Map<PharmacyDto>(entity);
        return Result<PharmacyDto>.Success(resultDto);
    }

    public async Task<Result<PharmacyDto>> UpdateAsync(Guid id, UpdatePharmacyDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
            return Result<PharmacyDto>.Failure(Error.NotFound("Pharmacy", id));

        _mapper.Map(dto, existing);
        existing.UpdateDate = DateTime.UtcNow;

        _repository.UpdateAsync(existing);
        await _unitOfWork.SaveChangesAsync();

        var updatedDto = _mapper.Map<PharmacyDto>(existing);
        return Result<PharmacyDto>.Success(updatedDto);
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing is null)
            return Result.Failure(Error.NotFound("Pharmacy", id));

        _repository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
