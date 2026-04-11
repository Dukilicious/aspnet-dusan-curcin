using CoreFitness.Domain.MembershipPlans;

namespace CoreFitness.Application.MembershipPlans;

public record MembershipPlanDto
(
    Guid Id,
    MembershipPlanType MembershipPlanType,
    string Description,
    List<string> Features,
    decimal Price,
    int MonthlyClassLimit,
    int FreeTrialWeeks
);