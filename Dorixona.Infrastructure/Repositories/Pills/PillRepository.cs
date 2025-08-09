using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using Dorixona.Domain.Models.PillsModel.PillEntities;
using Dorixona.Infrastructure.Data.DbContexts;
using Dorixona.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Dorixona.Infrastructure.Repositories.Pills;

public class PillRepository : GenericRepository<Pill>, IPillRepository
{
    public PillRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Result<Pill>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var pill = await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            return pill is null
                ? Result<Pill>.Failure(Error.Conflict("Pill not found."))
                : Result<Pill>.Success(pill);
        }
        catch (Exception ex)
        {
            return Result<Pill>.Failure(Error.Conflict($"Error fetching pill by Id: {ex.Message}"));
        }
    }

    public async Task<Result<IReadOnlyList<Pill>>> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            var pills = await _dbSet
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return Result<IReadOnlyList<Pill>>.Success(pills);
        }
        catch (Exception ex)
        {
            return Result<IReadOnlyList<Pill>>.Failure(Error.Conflict($"Error fetching pills: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> AddAsync(Pill pill, CancellationToken cancellationToken)
    {
        if (pill == null)
            return Result<bool>.Failure(Error.Conflict("Pill entity cannot be null."));

        try
        {
            await _dbSet.AddAsync(pill, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure(Error.Conflict($"Error adding pill: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> UpdateAsync(Pill pill, CancellationToken cancellationToken)
    {
        if (pill == null)
            return Result<bool>.Failure(Error.Conflict("Pill entity cannot be null."));

        try
        {
            _dbSet.Update(pill);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure(Error.Conflict($"Error updating pill: {ex.Message}"));
        }
    }

    public async Task<Result<bool>> DeleteAsync(Pill pill, CancellationToken cancellationToken)
    {
        if (pill == null)
            return Result<bool>.Failure(Error.Conflict("Pill entity cannot be null."));

        try
        {
            _dbSet.Remove(pill);
            await _context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Failure(Error.Conflict($"Error deleting pill: {ex.Message}"));
        }
    }

    public async Task<IReadOnlyList<Pill>> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync(cancellationToken);
    }
}