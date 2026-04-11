namespace CoreFitness.Application.MembershipPlans;

public interface IMembershipPlanQueries
{
    Task<IReadOnlyCollection<MembershipPlanDto>> GetAllWithFeaturesAsync(CancellationToken ct = default);
}