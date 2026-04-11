using CoreFitness.Application.MembershipPlans;

namespace CoreFitness.Presentation.ViewModels;

public class MembershipsViewModel
{
    public IReadOnlyCollection<MembershipPlanDto> MembershipPlans { get; set; } = [];
}