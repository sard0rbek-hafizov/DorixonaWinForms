using Dorixona.Domain.Models.AdminModel.AdminEntities;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;
using Dorixona.Infrastructure.Data.DbContexts;
using Dorixona.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Dorixona.Infrastructure.Repositories.Admins;

public class AdminRepository : GenericRepository<Admin>, IAdminRepository
{
    public AdminRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task CreateAsync(Admin admin)
    {
        if (admin == null)
            throw new ArgumentNullException(nameof(admin));

        await _dbSet.AddAsync(admin);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var admin = await GetByIdAsync(id);
        if (admin == null)
            throw new KeyNotFoundException($"Admin with Id '{id}' was not found.");

        _dbSet.Remove(admin);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsAsync(Guid id)
    {
        return await _dbSet.AnyAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Admin>> GetAllAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .Include(a => a.User)
            .Include(a => a.Users)
            .Include(a => a.Pharmacists)
            .Include(a => a.Pharmacies)
            .Include(a => a.Pills)
            .Include(a => a.Patients)
            .Include(a => a.Orders)
            .ToListAsync();
    }

    public async Task<Admin?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email must not be empty.", nameof(email));

        return await _dbSet
            .AsNoTracking()
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.User != null && a.User.Email == email, cancellationToken);
    }

    public async Task<Admin?> GetByIdAsync(Guid id)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(a => a.User)
            .Include(a => a.Users)
            .Include(a => a.Pharmacists)
            .Include(a => a.Pharmacies)
            .Include(a => a.Pills)
            .Include(a => a.Patients)
            .Include(a => a.Orders)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task UpdateAsync(Admin admin)
    {
        if (admin == null)
            throw new ArgumentNullException(nameof(admin));

        _dbSet.Update(admin);
        await _context.SaveChangesAsync();
    }
}
