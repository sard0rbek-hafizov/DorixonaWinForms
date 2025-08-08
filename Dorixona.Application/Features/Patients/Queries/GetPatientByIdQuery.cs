using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PatientModel.PatientDTO;
using MediatR;

namespace Dorixona.Application.Features.Patients.Queries;

public class GetPatientByIdQuery : IRequest<PatientDto>
{
    public Guid PatientId { get; set; }

    public class Handler : IRequestHandler<GetPatientByIdQuery, PatientDto>
    {
        private readonly IPatientQueryService _patientService;

        public Handler(IPatientQueryService patientService)
        {
            _patientService = patientService;
        }

        public async Task<PatientDto> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientProfileAsync(request.PatientId);

            if (patient is null)
                throw new KeyNotFoundException("Bemor topilmadi.");

            return new PatientDto
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                MiddleName = patient.MiddleName,
                Email = string.Empty, // Email User modelda
                PhoneNumber = string.Empty,
                BirthDate = patient.BirthDate,
                Address = patient.Address,
                AllergyInfo = patient.AllergyInfo,
                MedicalHistory = patient.MedicalHistory,
                EmergencyContact = patient.EmergencyContact,
                BloodType = patient.BloodType,
                HasChronicDiseases = patient.HasChronicDiseases,
                Gender = null,
                ProfileImageUrl = null,
                RegisteredAt = patient.CreateDate
            };
        }
    }
}

