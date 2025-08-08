using Dorixona.Domain.Models.PatientModel.PatientDTO;
using MediatR;

namespace Dorixona.Application.Features.Patients.Commands;

public class UpdatePatientCommand : IRequest<bool>
{
    public Guid PatientId { get; set; }
    public PatientUpdateDto PatientDto { get; set; } = default!;
}
