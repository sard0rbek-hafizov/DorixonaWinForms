using Dorixona.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Dorixona.Infrastructure.Data.Interceptors;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is null) return base.SavingChanges(eventData, result);

        foreach (var entry in eventData.Context.ChangeTracker.Entries<BaseParams>())
        {
            if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDelete = true;
                entry.Entity.UpdateDate = DateTime.UtcNow;
            }
        }

        return base.SavingChanges(eventData, result);
    }
}
