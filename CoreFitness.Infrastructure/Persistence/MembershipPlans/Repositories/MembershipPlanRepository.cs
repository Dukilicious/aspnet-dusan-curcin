using CoreFitness.Application.MembershipPlans;
using Microsoft.EntityFrameworkCore;

namespace CoreFitness.Infrastructure.Persistence.MembershipPlans.Repositories;

internal class MembershipPlanRepository(ApplicationDbContext context) : IMembershipPlanQueries
{
    public async Task<IReadOnlyCollection<MembershipPlanDto>> GetAllWithFeaturesAsync(CancellationToken ct = default)
    {
        return await context.MembershipPlans
            .OrderBy(x => x.SortOrder)
            .Select(x => new MembershipPlanDto(
                x.Id,
                x.MembershipPlanType,
                x.Description,
                x.Features
                    .OrderBy(x => x.SortOrder)
                    .Select(x => x.Description)
                    .ToList(),
                x.Price,
                x.MonthlyClassLimit,
                x.FreeTrialWeeks
            )).ToListAsync(ct);
    }
}