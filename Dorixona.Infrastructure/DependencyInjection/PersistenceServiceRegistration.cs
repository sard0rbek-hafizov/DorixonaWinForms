using Dorixona.Domain.Models.AdminModel.IAdminRepositories;
using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.UserModel.UserRepositories;
using Dorixona.Infrastructure.Repositories.Admins;
using Dorixona.Infrastructure.Repositories.Patients;
using Dorixona.Infrastructure.Repositories.Pharmacies;
using Dorixona.Infrastructure.Repositories.Pills;
using Dorixona.Infrastructure.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Dorixona.Infrastructure.DependencyInjection;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        // Admin
        services.AddScoped<IAdminRepository, AdminRepository>();

        // Patient
        services.AddScoped<IPatientRepository, PatientRepository>();

        // Pharmacy
        services.AddScoped<IPharmacyRepository, PharmacyRepository>();

        // Pill
        services.AddScoped<IPillRepository, PillRepository>();

        // User
        services.AddScoped<IUserRepository, UserRepository>();

        // Boshqa repositorylar qo‘shilsin:
        // services.AddScoped<ISomeOtherRepository, SomeOtherRepository>();

        return services;
    }
}
