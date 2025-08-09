using Dorixona.Domain.Models.AdminModel.IAdminRepositories;
using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.UserModel.UserRepositories;
using Dorixona.Infrastructure.Data.DbContexts;

namespace Dorixona.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IAdminRepository Admins { get; }
    public IPatientRepository Patients { get; }
    public IPharmacyRepository Pharmacies { get; }
    public IPillRepository Pills { get; }
    public IUserRepository Users { get; }

    public UnitOfWork(
        ApplicationDbContext context,
        IAdminRepository adminRepository,
        IPatientRepository patientRepository,
        IPharmacyRepository pharmacyRepository,
        IPillRepository pillRepository,
        IUserRepository userRepository)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        Admins = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
        Patients = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
        Pharmacies = pharmacyRepository ?? throw new ArgumentNullException(nameof(pharmacyRepository));
        Pills = pillRepository ?? throw new ArgumentNullException(nameof(pillRepository));
        Users = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}
