using AutoMapper;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PatientModel.PatientDTO;
using Dorixona.Domain.Models.PatientModel.PatientEntities;

namespace Dorixona.Application.Services.Patients;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public PatientService(IPatientRepository patientRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<PatientDto>> GetAllAsync()
    {
        var patients = await _patientRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<PatientDto>>(patients);
    }

    public async Task<PatientDto?> GetByIdAsync(Guid id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        return patient is null ? null : _mapper.Map<PatientDto>(patient);
    }

    public async Task<Result<PatientDto>> CreateAsync(PatientCreateDto dto)
    {
        // Mapping
        var patient = _mapper.Map<Patient>(dto);
        patient.Id = Guid.NewGuid();
        patient.CreateDate = DateTime.UtcNow;
        patient.UpdateDate = DateTime.UtcNow;

        await _patientRepository.AddAsync(patient);
        await _unitOfWork.SaveChangesAsync();

        var resultDto = _mapper.Map<PatientDto>(patient);
        return Result<PatientDto>.Success(resultDto);
    }

    public async Task<Result<PatientDto>> UpdateAsync(Guid id, PatientUpdateDto dto)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(id);

        if (existingPatient is null)
            return Result<PatientDto>.Failure(Error.NotFound("Patient", id));

        // Update mapping
        _mapper.Map(dto, existingPatient);
        existingPatient.UpdateDate = DateTime.UtcNow;

        await _patientRepository.UpdateAsync(existingPatient);
        await _unitOfWork.SaveChangesAsync();

        var resultDto = _mapper.Map<PatientDto>(existingPatient);
        return Result<PatientDto>.Success(resultDto);
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        var existingPatient = await _patientRepository.GetByIdAsync(id);

        if (existingPatient is null)
            return Result.Failure(Error.NotFound("Patient", id));

        await _patientRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
