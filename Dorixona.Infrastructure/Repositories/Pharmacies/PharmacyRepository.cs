using Dorixona.Domain.Models.PharmacyModel.Entities;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using Dorixona.Infrastructure.Data.DbContexts;
using Dorixona.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dorixona.Infrastructure.Repositories.Pharmacies;

public class PharmacyRepository : GenericRepository<Pharmacy>, IPharmacyRepository
{
    public PharmacyRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Pharmacy pharmacy)
    {
        if (pharmacy == null)
            throw new ArgumentNullException(nameof(pharmacy));

        await _dbSet.AddAsync(pharmacy);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var pharmacy = await _dbSet.FindAsync(id);
        if (pharmacy == null)
            throw new KeyNotFoundException($"Pharmacy with ID {id} not found.");

        _dbSet.Remove(pharmacy);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbSet.AsNoTracking().AnyAsync(p => p.Id == id);
    }

    public async Task<List<Pharmacy>> FilterAsync(string? name, string? address, string? phoneNumber)
    {
        var query = _dbSet.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(p => p.Name.Contains(name));

        if (!string.IsNullOrWhiteSpace(address))
            query = query.Where(p => p.Address.Contains(address));

        if (!string.IsNullOrWhiteSpace(phoneNumber))
            query = query.Where(p => p.PhoneNumber.Contains(phoneNumber));

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<List<Pharmacy>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<Pharmacy?> GetByIdAsync(Guid id)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Pharmacy?> GetByLicenseAsync(string licenseNumber, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking()
                           .FirstOrDefaultAsync(p => p.LicenseNumber == licenseNumber, cancellationToken);
    }

    public async Task UpdateAsync(Pharmacy pharmacy)
    {
        if (pharmacy == null)
            throw new ArgumentNullException(nameof(pharmacy));

        _dbSet.Update(pharmacy);
        await _context.SaveChangesAsync();
    }
}