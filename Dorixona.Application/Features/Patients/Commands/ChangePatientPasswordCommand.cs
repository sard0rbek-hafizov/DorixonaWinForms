using Dorixona.Domain.Models.PatientModel.PatientDTO;
using MediatR;

namespace Dorixona.Application.Features.Patients.Commands;

public class ChangePatientPasswordCommand : IRequest<bool>
{
    public Guid PatientId { get; set; }
    public PatientChangePasswordDto PasswordDto { get; set; } = default!;
}
