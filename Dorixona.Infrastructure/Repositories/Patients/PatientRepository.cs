using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PatientModel.PatientEntities;
using Dorixona.Infrastructure.Data.DbContexts;
using Dorixona.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dorixona.Infrastructure.Repositories.Patients;

public class PatientRepository : GenericRepository<Patient>, IPatientRepository
{
    public PatientRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task AddAsync(Patient patient, CancellationToken cancellationToken = default)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        await base.AddAsync(patient, cancellationToken);
        await SaveChangesAsync(cancellationToken);
    }

    public async Task AddAsync(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        await _dbSet.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid patientId)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(p => p.Id == patientId);
        if (entity == null)
            throw new KeyNotFoundException($"Patient with ID '{patientId}' not found.");

        Remove(entity);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<Patient?> GetByIdAsync(Guid patientId)
    {
        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == patientId);
    }

    public async Task<Patient?> GetByPassportAsync(string passportNumber, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(passportNumber))
            throw new ArgumentException("Passport number cannot be null or empty.", nameof(passportNumber));

        return await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(p => p.PassportNumber == passportNumber, cancellationToken);
    }

    public async Task UpdateAsync(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        Update(patient);
        await SaveChangesAsync();
    }
}