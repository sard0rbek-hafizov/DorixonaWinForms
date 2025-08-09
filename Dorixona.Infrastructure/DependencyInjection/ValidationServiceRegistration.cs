using Microsoft.Extensions.DependencyInjection;

namespace Dorixona.Infrastructure.DependencyInjection;

public static class ValidationServiceRegistration
{
    public static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
        // Misol uchun:

        // services.AddScoped<IUserValidator, UserValidator>();
        // services.AddScoped<IAdminValidator, AdminValidator>();
        // services.AddScoped<IPatientValidator, PatientValidator>();
        // services.AddScoped<IPharmacyValidator, PharmacyValidator>();
        // services.AddScoped<IPillValidator, PillValidator>();

        // Agar validatorlar hali yo‘q bo‘lsa, shu yerga keyin qo‘shish mumkin

        return services;
    }
}