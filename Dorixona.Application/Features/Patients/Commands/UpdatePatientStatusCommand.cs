using Dorixona.Domain.Models.PatientModel.PatientDTO;
using MediatR;

namespace Dorixona.Application.Features.Patients.Commands;


public class UpdatePatientStatusCommand : IRequest<bool>
{
    public PatientStatusUpdateDto StatusDto { get; set; } = default!;
}