using Dorixona.Domain.Models.PatientModel.PatientDTO;
using MediatR;

namespace Dorixona.Application.Features.Patients.Commands;

public class CreatePatientCommand : IRequest<Guid>
{
    public PatientCreateDto PatientDto { get; set; } = default!;
}
