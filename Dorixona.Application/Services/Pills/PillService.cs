using AutoMapper;
using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.PillsModel.PillEntities;

namespace Dorixona.Application.Services.Pills;

public class PillService : IPillService
{
    private readonly IPillRepository _pillRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PillService(
        IPillRepository pillRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _pillRepository = pillRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IEnumerable<PillDto>> GetAllAsync()
    {
        var result = await _pillRepository.GetAllAsync(CancellationToken.None);

        if (result.IsFailure)
            return Enumerable.Empty<PillDto>();

        return result.Value.Select(pill => _mapper.Map<PillDto>(pill));
    }

    public async Task<PillDto?> GetByIdAsync(Guid id)
    {
        var result = await _pillRepository.GetByIdAsync(id, CancellationToken.None);

        if (result.IsFailure || result.Value is null)
            return null;

        return _mapper.Map<PillDto>(result.Value);
    }

    public async Task<Result<PillDto>> CreateAsync(CreatePillDto dto)
    {
        var pill = _mapper.Map<Pill>(dto);
        pill.Id = Guid.NewGuid();
        pill.CreateDate = DateTime.UtcNow;
        pill.UpdateDate = DateTime.UtcNow;

        var addResult = await _pillRepository.AddAsync(pill, CancellationToken.None);

        if (addResult.IsFailure || !addResult.Value)
            return Result<PillDto>.Failure(Error.Failure("Database", "Failed to create pill."));

        await _unitOfWork.SaveChangesAsync();

        var pillDto = _mapper.Map<PillDto>(pill);
        return Result<PillDto>.Success(pillDto);
    }

    public async Task<Result<PillDto>> UpdateAsync(Guid id, UpdatePillDto dto)
    {
        var existingResult = await _pillRepository.GetByIdAsync(id, CancellationToken.None);

        if (existingResult.IsFailure || existingResult.Value is null)
            return Result<PillDto>.Failure(Error.NotFound("Pill", id));

        var pillToUpdate = existingResult.Value;

        // Update values
        _mapper.Map(dto, pillToUpdate);
        pillToUpdate.UpdateDate = DateTime.UtcNow;

        var updateResult = await _pillRepository.UpdateAsync(pillToUpdate, CancellationToken.None);

        if (updateResult.IsFailure || !updateResult.Value)
            return Result<PillDto>.Failure(Error.Failure("Database", "Failed to update pill."));

        await _unitOfWork.SaveChangesAsync();

        var pillDto = _mapper.Map<PillDto>(pillToUpdate);
        return Result<PillDto>.Success(pillDto);
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        var existingResult = await _pillRepository.GetByIdAsync(id, CancellationToken.None);

        if (existingResult.IsFailure || existingResult.Value is null)
            return Result.Failure(Error.NotFound("Pill", id));

        var deleteResult = await _pillRepository.DeleteAsync(existingResult.Value, CancellationToken.None);

        if (deleteResult.IsFailure || !deleteResult.Value)
            return Result.Failure(Error.Failure("Database", "Failed to delete pill."));

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
