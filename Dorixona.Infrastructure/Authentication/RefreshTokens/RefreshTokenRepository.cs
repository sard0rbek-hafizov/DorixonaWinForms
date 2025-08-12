using Dorixona.Infrastructure.Authentication.Identity;
using Dorixona.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
namespace Dorixona.Infrastructure.Authentication.RefreshTokens;

public class RefreshTokenRepository : IRefreshTokenRepository4
{
    private readonly ApplicationDbContext _applicationDbContext;

    public RefreshTokenRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _applicationDbContext.Set<RefreshToken>()
            .AsNoTracking()
            .FirstOrDefaultAsync(rt => rt.Token == token);
    }

    public async Task AddAsync(RefreshToken refreshToken)
    {
        await _applicationDbContext.Set<RefreshToken>().AddAsync(refreshToken);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(RefreshToken refreshToken)
    {
        _applicationDbContext.Set<RefreshToken>().Update(refreshToken);
        await _applicationDbContext.SaveChangesAsync();
    }
}