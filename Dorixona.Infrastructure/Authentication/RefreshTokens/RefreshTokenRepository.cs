using Dorixona.Infrastructure.Authentication.Identity;
using Microsoft.EntityFrameworkCore;
namespace Dorixona.Infrastructure.Authentication.RefreshTokens;

public class RefreshTokenRepository : IRefreshTokenRepository4
{
    private readonly IdentityDbContext _context;

    public RefreshTokenRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _context.Set<RefreshToken>()
            .AsNoTracking()
            .FirstOrDefaultAsync(rt => rt.Token == token);
    }

    public async Task AddAsync(RefreshToken refreshToken)
    {
        await _context.Set<RefreshToken>().AddAsync(refreshToken);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RefreshToken refreshToken)
    {
        _context.Set<RefreshToken>().Update(refreshToken);
        await _context.SaveChangesAsync();
    }
}