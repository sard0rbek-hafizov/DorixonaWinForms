using Dorixona.Domain.Models.AdminModel.AdminDTO;
using FluentValidation;

namespace Dorixona.Application.Validators.Admins;

public class AdminStatsQueryValidator : AbstractValidator<AdminDashboardStatsDto>
{
    public AdminStatsQueryValidator()
    {
        RuleForEach(x => new[]
        {
            x.TotalUsers,
            x.ActiveUsers,
            x.TotalPharmacists,
            x.TotalPatients,
            x.TotalPills,
            x.TotalOrders,
            x.OrdersToday,
            x.PaidOrders,
            x.TotalPharmacies
        }).GreaterThanOrEqualTo(0);

        RuleFor(x => x.TotalRevenue).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TodayRevenue).GreaterThanOrEqualTo(0);
    }
}
