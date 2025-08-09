using Dorixona.Domain.Models.AdminModel.IAdminRepositories;
using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.UserModel.UserRepositories;

namespace Dorixona.Infrastructure.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    IAdminRepository Admins { get; }
    IPatientRepository Patients { get; }
    IPharmacyRepository Pharmacies { get; }
    IPillRepository Pills { get; }
    IUserRepository Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
