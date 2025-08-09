using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UserModel.UserRepositories;
using Dorixona.Infrastructure.Data.DbContexts;
using Dorixona.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dorixona.Infrastructure.Repositories.Users;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted, cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be null or empty.", nameof(email));

        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
    }

    public override async Task<IReadOnlyList<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(u => !u.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _dbSet
            .AsNoTracking()
            .Where(u => !u.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<User>> GetFilteredAsync(
        string? fullName,
        string? email,
        Role? role,
        UserStatus? status,
        Gender? gender,
        int pageNumber,
        int pageSize)
    {
        if (pageNumber <= 0) pageNumber = 1;
        if (pageSize <= 0) pageSize = 10;

        var query = _dbSet.AsNoTracking().Where(u => !u.IsDeleted);

        if (!string.IsNullOrWhiteSpace(fullName))
            query = query.Where(u => u.FullName.Contains(fullName));

        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(u => u.Email.Contains(email));

        if (role.HasValue)
            query = query.Where(u => u.Role == role.Value);

        if (status.HasValue)
            query = query.Where(u => u.Status == status.Value);

        if (gender.HasValue)
            query = query.Where(u => u.Gender == gender.Value);

        return await query
            .OrderBy(u => u.FirstName)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        await _dbSet.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        _dbSet.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        // Soft delete
        user.IsDeleted = true;
        _dbSet.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid user ID.", nameof(id));

        return await _dbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
    }
}